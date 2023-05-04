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
        }

        public void GenerateReservadas()
        {
            /*AGREGAR EL CÓDIGO QUE ESCRIBA LA FUNCIÓN  RESERVADAS EN CÓDIGO JAVA 
              AGREGÁNDOLE A LA VARIABLE CODELINES LAS LÍNEAS DE CÓDIGO */
        }

    }
}
