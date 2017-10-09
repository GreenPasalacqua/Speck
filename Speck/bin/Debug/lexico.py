import sys
import os

RESERVADAS = ("main", "if", "then", "else", "repeat", "while", "until", "cin", "cout", "real", "int", "boolean")
SIMBOLOS = ('+', '-', '*', '/', '=', '<', '>', '!', ':', '(', ')', '{', '}', ',', ';')
LINEA = " Ln "
COLUMNA = " Col "
SEPARADOR = '.' * 10
OPERADOR = "Operador"
REAL = "Constante numerica real"
ENTERA = "Constante numerica entera"
RESERVADA = "Palabra reservada"
IDENTIFICADOR = "Identificador"
ESPECIAL = "Simbolo especial"

with open(sys.argv[1], "r") as f:
    codigoFuente = f.read()

i = 0
contador_linea = contador_columna = 1

lexema_temp = ""
lexemas_con_tipos = []
lexemas_interno = []
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


def agrega_lexema(tipo):
    lexemas_con_tipos.append(lexema_temp + SEPARADOR + tipo)
    lexemas_interno.append(lexema_temp + LINEA + str(contador_linea) + COLUMNA + str(contador_columna - len(lexema_temp)))


def otro():
    if i < len(codigoFuente) and codigoFuente[i] not in SIMBOLOS and not str.isalnum(codigoFuente[i]) and not str.isspace(codigoFuente[i]):
        errores.append(codigoFuente[i] + LINEA + str(contador_linea) + COLUMNA + str(contador_columna))
        avanza()


def menor_mayor():
    crea()
    if i < len(codigoFuente) and codigoFuente[i] == '=':
        concatena()
        agrega_lexema(OPERADOR)
    else:
        agrega_lexema(OPERADOR)
        otro()


def simbolo_dos_caracteres():
    crea()
    if i < len(codigoFuente) and codigoFuente[i] == '=':
        concatena()
        agrega_lexema(OPERADOR)
    else:
        errores.append(lexema_temp + LINEA + str(contador_linea) + COLUMNA + str(contador_columna - 1))


def constante_numerica():
    while i < len(codigoFuente) and str.isdigit(codigoFuente[i]):
        concatena()
    if i < len(codigoFuente) and codigoFuente[i] == '.':
        concatena()
        if i < len(codigoFuente) and str.isdigit(codigoFuente[i]):
            concatena()
            while i < len(codigoFuente) and str.isdigit(codigoFuente[i]):
                concatena()
            agrega_lexema(REAL)
            otro()
    else:
        agrega_lexema(ENTERA)
        otro()


def mas_menos():
    global lexema_temp
    simbolo_temporal = codigoFuente[i]
    crea()
    if i < len(codigoFuente) and codigoFuente[i] == simbolo_temporal:
        if lexemas_con_tipos:
            token_anterior = lexemas_con_tipos[-1].split(SEPARADOR, 1)
            if IDENTIFICADOR == token_anterior[1]:

                lexema_temp = simbolo_temporal * 2
                lexemas_con_tipos.append(lexema_temp + SEPARADOR + OPERADOR)

                avanza()
                lexema_temp = ":="
                lexemas_interno.append(lexema_temp + LINEA + str(contador_linea) + COLUMNA + str(contador_columna - 2))

                lexema_temp = token_anterior[0]
                lexemas_interno.append(lexema_temp + LINEA + str(contador_linea) + COLUMNA + str(contador_columna - 2))

                lexema_temp = simbolo_temporal
                lexemas_interno.append(lexema_temp + LINEA + str(contador_linea) + COLUMNA + str(contador_columna - 2))

                lexema_temp = '1'
                lexemas_interno.append(lexema_temp + LINEA + str(contador_linea) + COLUMNA + str(contador_columna - 2))
            else:
                concatena()
                agrega_lexema(OPERADOR)
        else:
            concatena()
            agrega_lexema(OPERADOR)
    else:
        agrega_lexema(OPERADOR)
        otro()


while i < len(codigoFuente):
    if str.isspace(codigoFuente[i]):
        if codigoFuente[i] == '\n':
            contador_columna = 1
            contador_linea += 1
        elif codigoFuente[i] == '\t':
            contador_columna += 4
        else:
            contador_columna += 1
        i += 1
    elif str.isalpha(codigoFuente[i]):
        crea()
        while i < len(codigoFuente) and str.isalnum(codigoFuente[i]):
            concatena()
        if lexema_temp in RESERVADAS:
            agrega_lexema(RESERVADA)
        else:
            agrega_lexema(IDENTIFICADOR)
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
            agrega_lexema(OPERADOR)
            otro()
    elif codigoFuente[i] == '*':
        crea()
        agrega_lexema(OPERADOR)
    elif codigoFuente[i] == '(' or codigoFuente[i] == ')' or codigoFuente[i] == '{' or codigoFuente[i] == '}' or codigoFuente[i] == ',' or codigoFuente[i] == ';':
        crea()
        agrega_lexema(ESPECIAL)
    elif codigoFuente[i] == '<' or codigoFuente[i] == '>':
        menor_mayor()
    elif codigoFuente[i] == '=' or codigoFuente[i] == '!' or codigoFuente[i] == ':':
        simbolo_dos_caracteres()
    else:
        otro()

if not os.path.exists(directorio_lexico):
    os.makedirs(directorio_lexico)

with open(directorio_lexico + os.path.sep + "lexemas.txt", "w") as archivo_lexemas:
    for lex in lexemas_con_tipos:
        archivo_lexemas.write(lex + '\n')

with open(directorio_lexico + os.path.sep + "errores_lexicos.txt", "w") as archivo_errores_lexicos:
    for error in errores:
        archivo_errores_lexicos.write(error + '\n')

with open(directorio_lexico + os.path.sep + "lexemas_interno.txt", "w") as archivo_lexemas_interno:
    for lex in lexemas_interno:
        archivo_lexemas_interno.write(lex + '\n')
