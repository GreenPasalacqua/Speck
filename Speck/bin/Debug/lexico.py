import sys, os

RESERVADAS = ("main", "if", "then", "else", "end", "do", "while", "repeat", "until", "cin", "cout", "real", "int", "boolean")
SIMBOLOS = ('+', '-', '*', '/', '%', '=', '<', '>', '!', ':', '(', ')', '{', '}', ',', ';')

with open(sys.argv[1], "r") as f:
    codigoFuente = f.read()
i = 0
contador_linea = contador_columna = 1
lexema_temp = ""
lexemas = []
errores = []
directorio_lexico = os.path.dirname(os.path.realpath(__file__)) + os.path.sep + "Lexico"

def avanza():
    global i, contador_columna
    i += 1
    contador_columna += 1

def crea():
    global lexema_temp
    lexema_temp = codigoFuente[i]
    avanza()

def concatena():
    global lexema_temp
    lexema_temp += codigoFuente[i]
    avanza()

def otro():
    if i < len(codigoFuente) and codigoFuente[i] not in SIMBOLOS and not str.isalnum(codigoFuente[i]) and not str.isspace(codigoFuente[i]):
        errores.append(codigoFuente[i] + " Ln " + str(contador_linea) + " Col " + str(contador_columna))
        avanza()

def menor_mayor():
    crea()
    if i < len(codigoFuente) and codigoFuente[i] == '=':
        concatena()
        lexemas.append(lexema_temp + "..........Operador")
    else:
        lexemas.append(lexema_temp + "..........Operador")
        otro()

def simbolo_dos_caracteres():
    crea()
    if i < len(codigoFuente) and codigoFuente[i] == '=':
        concatena()
        lexemas.append(lexema_temp + "..........Operador")
    else:
        errores.append(lexema_temp + " Ln " + str(contador_linea) + " Col " + str(contador_columna - 1))

def constante_numerica():
    while i < len(codigoFuente) and str.isdigit(codigoFuente[i]):
        concatena()
    if i < len(codigoFuente) and codigoFuente[i] == '.':
        concatena()
        if i < len(codigoFuente) and str.isdigit(codigoFuente[i]):
            concatena()
            while i < len(codigoFuente) and str.isdigit(codigoFuente[i]):
                concatena()
            lexemas.append(lexema_temp + "..........Constante numerica real")
            otro()
    else:
        lexemas.append(lexema_temp + "..........Constante numerica entera")
        otro()

def mas_menos():
    simbolo_temporal = codigoFuente[i]
    crea()
    if i < len(codigoFuente) and codigoFuente[i] == simbolo_temporal:
        concatena()
        lexemas.append(lexema_temp + "..........Operador")
    elif i < len(codigoFuente) and str.isdigit(codigoFuente[i]):
        concatena()
        constante_numerica()
    else:
        lexemas.append(lexema_temp + "..........Operador")
        otro()

while i < len(codigoFuente):
    if str.isspace(codigoFuente[i]):
        if codigoFuente[i] == '\n':
            contador_columna = 1
            contador_linea += 1
        else:
            contador_columna += 1
        i += 1
    elif str.isalpha(codigoFuente[i]):
        crea()
        while i < len(codigoFuente) and str.isalnum(codigoFuente[i]):
            concatena()
        if lexema_temp in RESERVADAS:
            lexemas.append(lexema_temp + "..........Palabra reservada")
        else:
            lexemas.append(lexema_temp + "..........Identificador")
        otro()
    elif codigoFuente[i] == '+' or codigoFuente[i] == '-':
        mas_menos()
    elif str.isdigit(codigoFuente[i]):
        crea()
        constante_numerica()
    elif codigoFuente[i] == '/':
        crea()
        if i < len(codigoFuente) and codigoFuente[i] == '*':
            avanza()
            fin_comentario = False
            while i < len(codigoFuente) and not fin_comentario:
                while i < len(codigoFuente) and codigoFuente[i] != '*':
                    avanza()
                avanza()
                while i < len(codigoFuente) and codigoFuente[i] == '*':
                    avanza()
                if i < len(codigoFuente) and codigoFuente[i] == '/':
                    fin_comentario = True
                avanza()
        elif i < len(codigoFuente) and codigoFuente[i] == '/':
            while i < len(codigoFuente) and codigoFuente[i] != '\n':
                avanza()
        else:
            lexemas.append(lexema_temp + "..........Operador")
            otro()
    elif codigoFuente[i] == '*' or codigoFuente[i] == '%':
        crea()
        lexemas.append(lexema_temp + "..........Operador")
    elif codigoFuente[i] == '(' or codigoFuente[i] == ')' or codigoFuente[i] == '{' or codigoFuente[i] == '}' or codigoFuente[i] == ',' or codigoFuente[i] == ';':
        crea()
        lexemas.append(lexema_temp + "..........Simbolo especial")
    elif codigoFuente[i] == '<' or codigoFuente[i] == '>':
        menor_mayor()
    elif codigoFuente[i] == '=' or codigoFuente[i] == '!' or codigoFuente[i] == ':':
        simbolo_dos_caracteres()
    else:
        otro()

if not os.path.exists(directorio_lexico):
    os.makedirs(directorio_lexico)

with open(directorio_lexico + os.path.sep + "lexemas.txt", "w") as archivo_lexemas:
    for lex in lexemas:
        archivo_lexemas.write(lex + '\n')

with open(directorio_lexico + os.path.sep + "errores_lexicos.txt", "w") as archivo_errores_lexicos:
    for error in errores:
        archivo_errores_lexicos.write(error + '\n')
