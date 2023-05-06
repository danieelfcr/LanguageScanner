import java.util.Scanner;
public class Definitive_test_2 {
public static void main(String[] args) {
System.out.println("Enter your program");
Scanner in = new Scanner(System.in);
String program = in.nextLine() + " ";
int index = 0;
int actual_state = 0;
int[] final_states = {0,1,3,5};
String command = "";
		while (index < program.length()) {
			char lexeme = program.charAt(index);
			String symbol = identify_SET(lexeme);
			if (symbol.equals("")) {
				symbol = identify_TERMINAL(lexeme);
			}
			if (symbol.equals("")) {
				System.out.println("Simbolo no reconocido");
				break;
			}

			switch (actual_state) {
				case 0: {
					switch (symbol)
					{
						case "DIGITO":{
							actual_state = 1;
							command += lexeme;
						}break;

						case "-":{
							actual_state = 2;
							command += lexeme;
						}break;

						case ".":{
							actual_state = 3;
							command += lexeme;
						}break;

						case "%":{
							actual_state = 3;
							command += lexeme;
						}break;

						case "$":{
							actual_state = 4;
							command += lexeme;
						}break;

						case "LETRA":{
							actual_state = 5;
							command += lexeme;
						}break;

						case "(":{
							actual_state = 3;
							command += lexeme;
						}break;

						case ")":{
							actual_state = 3;
							command += lexeme;
						}break;

						case "BLANK_SPACE":{
							actual_state = 0;
							command = "";
						}break;
						default:{
							System.out.println("Simbolo no reconocido");
							actual_state = 0;
							command = "";
						}break;
					}
				}break;

				case 1: {
					switch (symbol)
					{
						case "DIGITO":{
							actual_state = 1;
							command += lexeme;
						}break;
						case "BLANK_SPACE":{
							System.out.println("TOKEN 1");
							actual_state = 0;
							command = "";
						}break;
						default:{
							System.out.println("Se esperaba " + "DIGITO ");
							actual_state = 0;
							command = "";
						}break;
					}
				}break;

				case 2: {
					switch (symbol)
					{
						case ">":{
							actual_state = 3;
							command += lexeme;
						}break;
						default:{
							System.out.println("Se esperaba " + "> ");
							actual_state = 0;
							command = "";
						}break;
					}
				}break;

				case 3: {
					switch (symbol)
					{
						case "BLANK_SPACE":{
							if (command.equals("->"))
								System.out.println("TOKEN 2");
							if (command.equals("."))
								System.out.println("TOKEN 3");
							if (command.equals("%"))
								System.out.println("TOKEN 4");
							if (command.equals("$."))
								System.out.println("TOKEN 5");
							if (command.equals("("))
								System.out.println("TOKEN 7");
							if (command.equals(")"))
								System.out.println("TOKEN 8");
							actual_state = 0;
							command = "";
						}break;
						default:{
							System.out.println("Simbolo no reconocido");
							actual_state = 0;
							command = "";
						}break;
					}
				}break;

				case 4: {
					switch (symbol)
					{
						case ".":{
							actual_state = 3;
							command += lexeme;
						}break;
						default:{
							System.out.println("Se esperaba " + ". ");
							actual_state = 0;
							command = "";
						}break;
					}
				}break;

				case 5: {
					switch (symbol)
					{
						case "DIGITO":{
							actual_state = 5;
							command += lexeme;
						}break;
						case "LETRA":{
							actual_state = 5;
							command += lexeme;
						}break;
						case "BLANK_SPACE":{
							System.out.println(RESERVADAS(command, 6));
							actual_state = 0;
							command = "";
						}break;
						default:{
							System.out.println("Se esperaba " + "DIGITO LETRA ");
							actual_state = 0;
							command = "";
						}break;
					}
				}break;

			}
			index++;
		}

		if (isFinalState(actual_state, final_states) && index == program.length()) {
			System.out.println("PROGRAMA CORRECTO");
		} else {
			System.out.println("FALLO EN EL PROGRAMA");
		}
}
	static boolean isFinalState(int state, int[] final_states) {
		for (int i = 0; i < final_states.length; i++) {
			if (final_states[i] == state)
				return true;
		}
		return false;
	}

static String identify_TERMINAL(char lexeme) {
		if (lexeme == '-')
				return "-";
		if (lexeme == '>')
				return ">";
		if (lexeme == '.')
				return ".";
		if (lexeme == '%')
				return "%";
		if (lexeme == '$')
				return "$";
		if (lexeme == '(')
				return "(";
		if (lexeme == ')')
				return ")";
		if (lexeme == ' ')
				return "BLANK_SPACE";
		return "";

	}

static String identify_SET(char lexeme) {
	int lexeme_value = (int)lexeme;
	int LETRA0_INFERIOR = (int)'A';
	int LETRA0_SUPERIOR = (int)'Z';
	if (lexeme_value >= LETRA0_INFERIOR  && lexeme_value <= LETRA0_SUPERIOR)
		return "LETRA";
	int LETRA1_INFERIOR = (int)'a';
	int LETRA1_SUPERIOR = (int)'z';
	if (lexeme_value >= LETRA1_INFERIOR  && lexeme_value <= LETRA1_SUPERIOR)
		return "LETRA";
	int LETRA2_ONLY = (int)'_';
	if (lexeme_value == LETRA2_ONLY)
		return "LETRA";
	int DIGITO0_INFERIOR = (int)'0';
	int DIGITO0_SUPERIOR = (int)'9';
	if (lexeme_value >= DIGITO0_INFERIOR  && lexeme_value <= DIGITO0_SUPERIOR)
		return "DIGITO";
	return "";
	}
	static String RESERVADAS (String command, int state) {
		if (command.equalsIgnoreCase("PROGRAM"))
			return "TOKEN 18";
		if (command.equalsIgnoreCase("INCLUDE"))
			return "TOKEN 19";
		if (command.equalsIgnoreCase("CONST"))
			return "TOKEN 20";
		if (command.equalsIgnoreCase("TYPE"))
			return "TOKEN 21";
		if (command.equalsIgnoreCase("VAR"))
			return "TOKEN 22";
		if (command.equalsIgnoreCase("RECORD"))
			return "TOKEN 23";
		if (command.equalsIgnoreCase("ARRAY"))
			return "TOKEN 24";
		if (command.equalsIgnoreCase("OF"))
			return "TOKEN 25";
		if (command.equalsIgnoreCase("PROCEDURE"))
			return "TOKEN 26";
		if (command.equalsIgnoreCase("FUNCTION"))
			return "TOKEN 27";
		if (command.equalsIgnoreCase("IF"))
			return "TOKEN 28";
		if (command.equalsIgnoreCase("THEN"))
			return "TOKEN 29";
		if (command.equalsIgnoreCase("ELSE"))
			return "TOKEN 30";
		if (command.equalsIgnoreCase("FOR"))
			return "TOKEN 31";
		if (command.equalsIgnoreCase("TO"))
			return "TOKEN 32";
		if (command.equalsIgnoreCase("WHILE"))
			return "TOKEN 33";
		if (command.equalsIgnoreCase("DO"))
			return "TOKEN 34";
		if (command.equalsIgnoreCase("EXIT"))
			return "TOKEN 35";
		if (command.equalsIgnoreCase("END"))
			return "TOKEN 36";
		if (command.equalsIgnoreCase("CASE"))
			return "TOKEN 37";
		if (command.equalsIgnoreCase("BREAK"))
			return "TOKEN 38";
		if (command.equalsIgnoreCase("DOWNTO"))
			return "TOKEN 39";
		return "TOKEN " + Integer.toString(state);
	}
}
