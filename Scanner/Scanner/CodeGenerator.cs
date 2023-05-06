using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using Scanner.ExpressionTree;

namespace Scanner
{
    
    public class CodeGenerator
    {

        public List<string> codeLines;
        private string fileName;
        private ExpressionTree.ExpressionTree expressionTree;
        List<string> actionFunctions;

        public CodeGenerator(ExpressionTree.ExpressionTree expressionTree, string fileName, List<string> actionFunctions)
        {
            this.expressionTree = expressionTree;
            this.fileName = fileName;
            codeLines = new List<string>();
            this.actionFunctions = actionFunctions;
            GenerateCode();
        }

        public void GenerateCode()
        {
            codeLines.Add("import java.util.Scanner;");
            codeLines.Add("public class " + fileName + " {");
            codeLines.Add("public static void main(String[] args) {");
            codeLines.Add("System.out.println(\"Enter your program\");");
            codeLines.Add("Scanner in = new Scanner(System.in);");
            codeLines.Add("String program = in.nextLine() + \" \";");
            codeLines.Add("int index = 0;");
            codeLines.Add("int actual_state = 0;");
            codeLines.Add("int[] final_states = {" + "};" ); //AGREGAR LOS ESTADOS FINALES
            codeLines.Add("String command = \"\";");

            //AQUI VA EL WHILE PRINCIPAL (PODRIA MANDARSE A LLAMAR A UN MÉTODO QUE LO HAGA A PARTE)

            GenerateMainWhile();

            //AQUI TERMINA EL WHILE PRINCIPAL

            GenerateIsFinalState();

            GenerateIdentifyTerminal();

            GenerateIdentifySet();

            GenerateActionFunctions(actionFunctions);

            codeLines.Add("}"); //FINAL DEL PROGRAMA JAVA



            //AQUI SE CREA EL ARCHIVO .JAVA
            string[] lines = codeLines.ToArray();
            File.WriteAllLines(fileName + ".java", lines);
            MessageBox.Show("Program created without problems");
        }

        public void GenerateMainWhile()
        {
            string auxLine;
            auxLine = "\t\tWhile (index < program.length()) {";
            codeLines.Add(auxLine);
            auxLine = "\t\t\tchar lexeme = program.charAt(index);";
            codeLines.Add(auxLine);
            auxLine = "\t\t\tString symbol = indentify_SET(lexeme);";
            codeLines.Add(auxLine);
            auxLine = "\t\t\tif (symbol.equals(\"\")) {";
            codeLines.Add(auxLine);
            auxLine = "\t\t\t\tsymbol = identify_TERMINAL(lexeme);";
            codeLines.Add(auxLine);
            auxLine = "\t\t\t}";
            codeLines.Add(auxLine);
            auxLine = "\t\t\tif (symbol.equals(\"\")) {";
            codeLines.Add(auxLine);
            auxLine = "\t\t\t\tSystem.out.println(\"Simbolo no reconocido\");";
            codeLines.Add(auxLine);
            auxLine = "\t\t\t\tbreak;";
            codeLines.Add(auxLine);
            auxLine = "\t\t\t}\n";
            codeLines.Add(auxLine);

            auxLine = "\t\t\tswitch (actual_state) {";
            codeLines.Add(auxLine);

            //Print the respective values for each state
            foreach (KeyValuePair<string, TransitionSummary> kvp in expressionTree.transitions)
            {
                string transition = kvp.Key;
                TransitionSummary state = expressionTree.transitions[transition];
                auxLine = "\t\t\t\tcase " + state.StateNumber + ": {";
                codeLines.Add(auxLine);

                //Evalute to define if is a final state, a repetitive state, initial state or middle state
                //it refers to the initial state
                if (state.StateNumber == 0)
                {
                    auxLine = "\t\t\t\t\tswitch (symbol)";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\t\t\t{";
                    codeLines.Add(auxLine);

                    foreach (string symbol in expressionTree.symbols)
                    {
                        if (expressionTree.transitions[transition].Transition[symbol].Count > 0)
                        {
                            if (new Regex("'\\S'").IsMatch(symbol))
                            {
                                if (symbol[1].Equals('"'))
                                {
                                    auxLine = "\t\t\t\t\t\tcase \"\\" + symbol[1] + "\":{";
                                }
                                else
                                {
                                    auxLine = "\t\t\t\t\t\tcase \"" + symbol[1] + "\":{";
                                }
                            }
                            else
                            {
                                auxLine = "\t\t\t\t\t\tcase \"" + symbol.Replace("'", string.Empty) + "\":{";
                            }
                            codeLines.Add(auxLine);
                            string nextState = string.Join(',', expressionTree.transitions[transition].Transition[symbol]);
                            auxLine = "\t\t\t\t\t\t\tactual_state = " + expressionTree.transitions[nextState].StateNumber + ";";
                            codeLines.Add(auxLine);
                            auxLine = "\t\t\t\t\t\t\tcommand += lexeme;";
                            codeLines.Add(auxLine);
                            auxLine = "\t\t\t\t\t\t}break;\n";
                            codeLines.Add(auxLine);
                        }
                    }

                    auxLine = "\t\t\t\t\t\tcase \"BLANK_SPACE\":{";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\t\t\t\t\tactual_state = 0;";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\t\t\t\t\tcommand = \"\";";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\t\t\t\t}break;";
                    codeLines.Add(auxLine);

                    auxLine = "\t\t\t\t\t\tdefault:{";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\t\t\t\t\tSystem.out.println(\"Simbolo no reconocido\")";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\t\t\t\t}break;";
                    codeLines.Add(auxLine);

                    auxLine = "\t\t\t\t\t}";
                    codeLines.Add(auxLine);
                }
                //It is a final state it must evaluate all the symbols in the case
                else if (state.State.Count == 1 && state.State[0] == expressionTree.terminalSymbol)
                {
                    auxLine = "\t\t\t\t\tswitch (symbol)";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\t\t\t{";
                    codeLines.Add(auxLine);

                    auxLine = "\t\t\t\t\t\tcase \"BLANK_SPACE\":{";
                    codeLines.Add(auxLine);

                    foreach (KeyValuePair<int, TokenSummary> ss in expressionTree.tokenInformation)
                    {
                        string value = ss.Value.TokenValue;
                        if (!new Regex("\\w\\w+").IsMatch(value))
                        {
                            int n = ss.Key;
                            auxLine = "\t\t\t\t\t\t\tif (command.equals(\"" + new Regex("'").Replace(value, string.Empty) + "\"))";
                            codeLines.Add(auxLine);
                            auxLine = "\t\t\t\t\t\t\t\tSystem.out.println(\"TOKEN " + n + "\");";
                            codeLines.Add(auxLine);
                        }
                    }
                    auxLine = "\t\t\t\t\t\t\tactual_state = 0;";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\t\t\t\t\tcommand = \"\";";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\t\t\t\t}break;";
                    codeLines.Add(auxLine);

                    auxLine = "\t\t\t\t\t\tdefault:{";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\t\t\t\t\tSystem.out.println(\"Simbolo no reconocido\")";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\t\t\t\t}break;";
                    codeLines.Add(auxLine);

                    auxLine = "\t\t\t\t\t}";
                    codeLines.Add(auxLine);
                }
                //It is the case for a middle state without the extendeSymbol
                else if (!state.State.Contains(expressionTree.terminalSymbol))
                {
                    auxLine = "\t\t\t\t\tswitch (symbol)";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\t\t\t{";
                    codeLines.Add(auxLine);

                    string expected = "";
                    foreach (KeyValuePair<string, List<int>> tt in state.Transition)
                    {
                        if (tt.Value.Count > 0)
                        {
                            string value = tt.Key;

                            if (new Regex("'\\S'").IsMatch(value))
                            {
                                if (value[1].Equals('"'))
                                {
                                    auxLine = "\t\t\t\t\t\tcase \"\\" + value[1] + "\":{";
                                    expected += "\\" + value[1] + " ";
                                }
                                else
                                {
                                    auxLine = "\t\t\t\t\t\tcase \"" + value[1] + "\":{";
                                    expected += value[1] + " ";
                                }
                            }
                            else
                            {
                                auxLine = "\t\t\t\t\t\tcase \"" + value.Replace("'", string.Empty) + "\":{";
                                expected += new Regex("'").Replace(value, string.Empty) + " ";
                            }

                            codeLines.Add(auxLine);

                            int n = expressionTree.transitions[string.Join(',', tt.Value.ToArray())].StateNumber;

                            auxLine = "\t\t\t\t\t\t\tactual state = " + n + ";";
                            codeLines.Add(auxLine);
                            auxLine = "\t\t\t\t\t\t\tcommand += lexeme;";
                            codeLines.Add(auxLine);
                            auxLine = "\t\t\t\t\t\t}break;";
                            codeLines.Add(auxLine);
                        }
                    }

                    auxLine = "\t\t\t\t\t\tdefault:{";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\t\t\t\t\tSystem.out.println(\"Se esperaba \" + \"" + expected + "\")";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\t\t\t\t}break;";
                    codeLines.Add(auxLine);

                    auxLine = "\t\t\t\t\t}";
                    codeLines.Add(auxLine);
                }
                //It is a repetitive state
                else
                {
                    auxLine = "\t\t\t\t\tswitch (symbol)";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\t\t\t{";
                    codeLines.Add(auxLine);

                    string expected = "";
                    foreach (KeyValuePair<string, List<int>> tt in state.Transition)
                    {
                        if (tt.Value.Count > 0)
                        {
                            string value = tt.Key;
                            
                            if (new Regex("'\\S'").IsMatch(value))
                            {
                                if (value[1].Equals("\""))
                                {
                                    auxLine = "\t\t\t\t\t\tcase \"\\" + value[1] + "\":{";
                                }
                                else
                                {
                                    auxLine = "\t\t\t\t\t\tcase \"" + value[1] + "\":{";
                                }
                                expected += value[1] + " ";

                            }
                            else
                            {
                                auxLine = "\t\t\t\t\t\tcase \"" + value.Replace("'", string.Empty) + "\":{";
                                expected += value.Replace("'", string.Empty) + " ";
                            }

                            codeLines.Add(auxLine);

                            int n = expressionTree.transitions[string.Join(',', tt.Value.ToArray())].StateNumber;

                            auxLine = "\t\t\t\t\t\t\tactual state = " + n + ";";
                            codeLines.Add(auxLine);
                            auxLine = "\t\t\t\t\t\t\tcommand += lexeme;";
                            codeLines.Add(auxLine);
                            auxLine = "\t\t\t\t\t\t}break;";
                            codeLines.Add(auxLine);
                        }
                    }

                    auxLine = "\t\t\t\t\t\tcase \"BLANK_SPACE\":{";
                    codeLines.Add(auxLine);

                    int newState = expressionTree.tokenInformation[state.StateNumber].TokenNumber;
                    if (expressionTree.tokenInformation[state.StateNumber].CallMethod)
                    {
                        auxLine = "\t\t\t\t\t\t\tSystem.out.println(" + expressionTree.tokenInformation[state.StateNumber].Method + "(command, " + newState + "));";
                        codeLines.Add(auxLine);
                    }
                    else
                    {
                        auxLine = "\t\t\t\t\t\t\tSystem.out.println(\"TOKEN " + newState + "\")";
                        codeLines.Add(auxLine);
                    }

                    auxLine = "\t\t\t\t\t\t\tactual_state = 0;";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\t\t\t\t\tcommand = \"\";";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\t\t\t\t}break;";
                    codeLines.Add(auxLine);

                    auxLine = "\t\t\t\t\t\tdefault:{";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\t\t\t\t\tSystem.out.println(\"Se esperaba \" + \"" + expected + "\")";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\t\t\t\t}break;";
                    codeLines.Add(auxLine);

                    auxLine = "\t\t\t\t\t}";
                    codeLines.Add(auxLine);
                }

                auxLine = "\t\t\t\t}break;\n";
                codeLines.Add(auxLine);
            }

            auxLine = "\t\t\t}";
            codeLines.Add(auxLine);
            auxLine = "\t\t\tindex++;";
            codeLines.Add(auxLine);
            auxLine = "\t\t}\n";
            codeLines.Add(auxLine);

            auxLine = "\t\tif (isFinalState(actual_state, final_states) && index == program.length()) {";
            codeLines.Add(auxLine);
            auxLine = "\t\t\tSystem.out.println(\"PROGRAMA CORRECTO\");";
            codeLines.Add(auxLine);
            auxLine = "\t\t} else {";
            codeLines.Add(auxLine);
            auxLine = "\t\t\tSystem.out.println(\"FALLO EN EL PROGRAMA\");";
            codeLines.Add(auxLine);
            auxLine = "\t\t}";
            codeLines.Add(auxLine);
        }

        public void GenerateIsFinalState()
        {
            /*AGREGAR EL CÓDIGO QUE ESCRIBA LA FUNCIÓN ISFINALSTATE EN CÓDIGO JAVA 
              AGREGÁNDOLE A LA VARIABLE CODELINES LAS LÍNEAS DE CÓDIGO */
        }

        /// <summary>
        /// Procedure to add to the codeLines the lines about identify_TERMINAL function that uses generalTokenList from ExpressionTree class 
        /// </summary>
        /// <param name="codeLines">List with all the lines of the Java Program.</param>

        public void GenerateIdentifyTerminal()
        {
            string prueba = "";
            codeLines.Add("static String identify_TERMINAL(char lexeme) {\n");
            prueba += "static String identify_TERMINAL(char lexeme) {\n";
            List<string> alreadyUsedTokens = new List<string>();
            foreach (Node node in expressionTree.generalTokenSource)
            {
                if (node.kindSymbol == 0 && !alreadyUsedTokens.Contains(node.symbol) && node.symbol != "'#'") //terminal symbol
                {
                    alreadyUsedTokens.Add(node.symbol);
                    string symbol = node.symbol[1].ToString();

                    codeLines.Add("\t\tif (lexeme == \'" + symbol + "\')\n");
                    codeLines.Add("\t\t\t\treturn \"" + symbol + "\";\n");

                    prueba += "\t\tif (lexeme == \'" + symbol + "\')\n";
                    prueba += "\t\t\t\treturn \"" + symbol + "\";\n";

                }
            }

            codeLines.Add("\t\tif (lexeme == \' " + "\')\n");
            codeLines.Add("\t\t\t\treturn \"BLANK_SPACE\";\n");

            codeLines.Add("\t\treturn \"\";\n");
            codeLines.Add("}");


            prueba += "\t\tif (lexeme == \' " + "\')\n";
            prueba += "\t\t\t\treturn \"BLANK_SPACE\";\n";
            prueba += "\t\treturn \"\";\n";
            prueba += "}";
        }

        public void GenerateIdentifySet()
        {
            /*AGREGAR EL CÓDIGO QUE ESCRIBA LA FUNCIÓN IDENTIFY_SET EN CÓDIGO JAVA 
              AGREGÁNDOLE A LA VARIABLE CODELINES LAS LÍNEAS DE CÓDIGO */

            string initialText = Form1.text;    //Contiene el texto inicial del archivo
            deleteChars(ref initialText);       //Eliminar caracteres extra de la cadena

            string[] modifiedText = initialText.Split('\n');    //Separa la cadena por saltos de linea
            modifiedText = modifiedText.Where(x => !string.IsNullOrEmpty(x)).ToArray(); //Eliminar espacios nulos en el array
            int finalIndex = Array.IndexOf(modifiedText, "TOKENS"); //Encuentra el indice de TOKENS, indicando que hasta ahi se evaluará

            if (modifiedText[0].Contains("SETS"))
            {

                //string[] sets = { "LETRA='A'..'Z'+'a'..'z'+'_'", "DIGITO  = '0'..'9'", "SIMBOL='%'" };

                codeLines.Add("\nstatic String identify_SET(char lexeme) {"); //Inicia funcion de SETS
                codeLines.Add("\tint lexeme_value = (int)lexeme;");

                for (int i = 1; i < finalIndex; i++)
                {
                    string nombreSet = modifiedText[i].Split('=')[0].Trim();
                    string valorSet = modifiedText[i].Split('=')[1].Trim();
                    string[] conjuntosSet;


                    //Verifico los conjuntos de sets
                    conjuntosSet = valorSet.Split('+');


                    for (int j = 0; j < conjuntosSet.Length; j++)
                    {

                        if (conjuntosSet[j].Contains(".."))
                        { //Es un conjunto
                            conjuntosSet[j] = conjuntosSet[j].Replace("..", "$");
                            string[] limites = conjuntosSet[j].Split('$');

                            codeLines.Add("\tint " + nombreSet + j + "_INFERIOR = (int)" + limites[0] + ";");
                            codeLines.Add("\tint " + nombreSet + j + "_SUPERIOR = (int)" + limites[1] + ";");

                            codeLines.Add("\tif (lexeme_value >= " + nombreSet + j + "_INFERIOR  && lexeme_value <= " + nombreSet + j + "_SUPERIOR)");
                            codeLines.Add("\t\treturn \"" + nombreSet + "\";");

                        }
                        else //Es valor unico 
                        {
                            codeLines.Add("\tint " + nombreSet + j + "_ONLY = (int)" + conjuntosSet[j] + ";");

                            codeLines.Add("\tif (lexeme_value == " + nombreSet + j + "_ONLY)");
                            codeLines.Add("\t\treturn \"" + nombreSet + "\";");

                        }

                    }

                }
                codeLines.Add("}");
            }
        }


        /// <summary>
        /// Procedure to add to the codeLines the lines about Actions fuction that is call for a Token that have a actions call in
        /// </summary>
        /// <param name="codeLines">List with all the lines of the Java Program.</param>
        /// <param name="functions">It refers to all the actions that were found in the grammar and each elemend is an action function.</param>
        public void GenerateActionFunctions(List<string> functions)
        {
            string auxLine;
            foreach (string function in functions)
            {
                string funName = new Regex("\\s*[A-Za-z]+\\s*\\(\\s*\\)\\s*").Match(function).Value;
                funName = new Regex("\\s*\\(\\s*\\)\\s*").Replace(funName, string.Empty).Trim();
                auxLine = "\tstatic String " + funName + " (String command, int state) {";
                codeLines.Add(auxLine);

                foreach (Match match in new Regex("\\s*([0-9]|([1-9][0-9]*))\\s*=\\s*'([A-Z]|[a-z])+'\\s*").Matches(function))
                {
                    string acToken = match.Value;
                    string num = new Regex("[1-9][0-9]*").Match(acToken).Value;
                    string word = new Regex("[A-Za-z]+").Match(acToken).Value;

                    auxLine = "\t\tif (command.equalsIsIgnoreCase(\"" + word + "\"))";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\treturn \"TOKEN " + num + "\";";
                    codeLines.Add(auxLine);
                }

                auxLine = "\t\treturn \"TOKEN \" + state.toString();";
                codeLines.Add(auxLine);
                auxLine = "\t}";
                codeLines.Add(auxLine);
            }
        }


        //Metodo que elimina espacios, tabulaciones y retornos de carro de la cadena
        void deleteChars(ref string initialText)
        {
            string initialText2 = initialText.Replace(" ", string.Empty); // elimina los espacios en blanco
            string initialText3 = initialText2.Replace("\t", string.Empty); // elimina las tabulaciones
            initialText = initialText3.Replace("\r", string.Empty); // elimina los retornos de carro
        }

    }
}
