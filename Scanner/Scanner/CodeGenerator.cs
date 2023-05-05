using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            

            //AQUI TERMINA EL WHILE PRINCIPAL

            GenerateIsFinalState();

            GenerateIdentifyTerminal();

            GenerateIdentifySet();

            GenerateReservadas();

            codeLines.Add("}"); //FINAL DEL PROGRAMA JAVA



            //AQUI SE CREA EL ARCHIVO .JAVA
            string[] lines = codeLines.ToArray();
            File.WriteAllLines(fileName + ".java", lines);
            MessageBox.Show("Program created without problems");
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

            string initialText = Form1.text;    //Contiene el texto inicial del archivo
            deleteChars(ref initialText);       //Eliminar caracteres extra de la cadena

            string[] modifiedText = initialText.Split('\n');    //Separa la cadena por saltos de linea
            int finalIndex = Array.IndexOf(modifiedText, "TOKENS"); //Encuentra el indice de TOKENS, indicando que hasta ahi se evaluará

            if (modifiedText[0].Contains("SETS"))
            {

                string[] sets = { "LETRA='A'..'Z'+'a'..'z'+'_'", "DIGITO  = '0'..'9'", "SIMBOL='%'" };

                codeLines.Add("static String identify_SET(char lexeme) {"); //Inicia funcion de SETS
                codeLines.Add("int lexeme_value = (int)lexeme;");

                for (int i = 1; i < finalIndex; i++)
                {
                    string nombreSet = sets[i].Split('=')[0].Trim();
                    string valorSet = sets[i].Split('=')[1].Trim();
                    string[] conjuntosSet;


                    //Verifico los conjuntos de sets
                    conjuntosSet = valorSet.Split('+');


                    for (int j = 0; j < conjuntosSet.Length; j++)
                    {

                        if (conjuntosSet[j].Contains(".."))
                        { //Es un conjunto
                            conjuntosSet[j] = conjuntosSet[j].Replace("..", "$");
                            string[] limites = conjuntosSet[j].Split('$');

                            codeLines.Add("int " + nombreSet + j + "_INFERIOR = (int)" + limites[0] + ";");
                            codeLines.Add("int " + nombreSet + j + "_SUPERIOR = (int)" + limites[1] + ";");

                            codeLines.Add("if (lexeme_value >= " + nombreSet + j + "_INFERIOR  && lexeme_value <= " + nombreSet + j + "_SUPERIOR)");
                            codeLines.Add("return \"" + nombreSet + "\";");

                        }
                        else //Es valor unico 
                        {
                            codeLines.Add("int " + nombreSet + j + "_ONLY = (int)" + conjuntosSet[j] + ";");

                            codeLines.Add("if (lexeme_value == " + nombreSet + j + "_ONLY)");
                            codeLines.Add("return \"" + nombreSet + "\";");

                        }

                    }

                }
            }
        }

        public void GenerateReservadas()
        {
            /*AGREGAR EL CÓDIGO QUE ESCRIBA LA FUNCIÓN  RESERVADAS EN CÓDIGO JAVA 
              AGREGÁNDOLE A LA VARIABLE CODELINES LAS LÍNEAS DE CÓDIGO */
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
