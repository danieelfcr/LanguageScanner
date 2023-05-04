using System;
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

        private List<string> codeLines;
        private string fileName;
        private ExpressionTree.ExpressionTree expressionTree;

        public CodeGenerator(ExpressionTree.ExpressionTree expressionTree, string fileName)
        {
            this.expressionTree = expressionTree;
            this.fileName = fileName;
            codeLines = new List<string>();
        }

        public void GenerateCode(List<string> actionFunctions)
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
                auxLine = "\t\t\t\tcase " + expressionTree.transitions[transition].StateNumber + ": {";
                codeLines.Add(auxLine);

                //Evalute to define if is a final state, a repetitive state, initial state or middle state
                //it refers to the initial state
                if (expressionTree.transitions[transition].StateNumber == 0)
                {
                    auxLine = "\t\t\t\t\tswitch (symbol)";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\t\t\t{";

                    foreach (string symbol in expressionTree.symbols)
                    {
                        if (expressionTree.transitions[transition].Transition[symbol].Count > 0)
                        {
                            auxLine = "\t\t\t\t\t\tcase \"" + symbol + "\":{";
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

                    auxLine = "\t\t\t\t\t\tdefault:{";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\t\t\t\t\tSystem.out.println(\"Simbolo no reconocido\")";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\t\t\t\t}break;";
                    codeLines.Add(auxLine);

                    auxLine = "\t\t\t\t\t}";
                    codeLines.Add(auxLine);
                    auxLine = "\t\t\t\t}break;";

                }
                else
                {
                    //FALTAN ESTADO FINAL, ESTADO INTERMEDIO Y ESTADO REPETITIVO
                }

                auxLine = "\t\t\t\t}break;\n";
                codeLines.Add(auxLine);
            }

            auxLine = "\t\t\t}";
            codeLines.Add(auxLine);
            auxLine = "\t\t\tindex++;";
            codeLines.Add(auxLine);
        }

        public void GenerateIsFinalState()
        {
            /*AGREGAR EL CÓDIGO QUE ESCRIBA LA FUNCIÓN ISFINALSTATE EN CÓDIGO JAVA 
              AGREGÁNDOLE A LA VARIABLE CODELINES LAS LÍNEAS DE CÓDIGO */
        }

        public void GenerateIdentifyTerminal()
        {
            /*AGREGAR EL CÓDIGO QUE ESCRIBA LA FUNCIÓN IDENTIFY_TERMINAL EN CÓDIGO JAVA 
              AGREGÁNDOLE A LA VARIABLE CODELINES LAS LÍNEAS DE CÓDIGO */
        }

        public void GenerateIdentifySet()
        {
            /*AGREGAR EL CÓDIGO QUE ESCRIBA LA FUNCIÓN IDENTIFY_SET EN CÓDIGO JAVA 
              AGREGÁNDOLE A LA VARIABLE CODELINES LAS LÍNEAS DE CÓDIGO */
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
                    auxLine = "\t\t\treturn \"TOKEN" + num + "\";";
                    codeLines.Add(auxLine);
                }

                auxLine = "\t\treturn \"TOKEN \" + state.toString();";
                codeLines.Add(auxLine);
                auxLine = "\t}";
                codeLines.Add(auxLine);
            }
        }

    }
}
