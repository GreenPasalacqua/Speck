import sys
import os
import re
import subprocess
from anytree import Node, RenderTree, AsciiStyle
from anytree.dotexport import RenderTreeGraph

RESERVADAS = ("main", "if", "then", "else", "repeat", "while", "until", "cin", "cout", "real", "int", "boolean")

PRIMERO_TIPO = ("int", "real", "boolean")
PRIMERO_SENTENCIA = ("if", "while", "repeat", "cin", "cout", '{')
PRIMERO_EXPRESION_SIMPLE = ('(',)
PRIMERO_RELACION = ("<=", '<', '>', ">=", "==", "!=")
PRIMERO_SUMA_OP = ('+', '-')
PRIMERO_MULT_OP = ('*', '/')
SIGUIENTE_LISTA_VARIABLES = (';',)
SIGUIENTE_LISTA_SENTENCIAS = ('}',)
# SIGUIENTE_SENTENCIA = PRIMERO_SENTENCIA + SIGUIENTE_LISTA_SENTENCIAS


SIGUIENTE_SENTENCIAS = PRIMERO_SENTENCIA + SIGUIENTE_LISTA_SENTENCIAS
SIGUIENTE_SENTENCIA = SIGUIENTE_LISTA_SENTENCIAS
SIGUIENTE_SELECCION = ("while", "repeat", "cin", "cout", '{', '}')
SIGUIENTE_ITERACION = ("if", "repeat", "cin", "cout", '{', '}')
SIGUIENTE_REPETICION = ("if", "while", "cin", "cout", '{', '}')
SIGUIENTE_CIN = ("if", "while", "repeat", "cout", '{', '}')
SIGUIENTE_COUT = ("if", "while", "repeat", "cin", '{', '}')
SIGUIENTE_BLOQUE = ("else", "until", "if", "while", "repeat", "cin", 'cout', '}')
SIGUIENTE_LISTA_DECLARACION = PRIMERO_SENTENCIA + SIGUIENTE_LISTA_SENTENCIAS

# SIGUIENTE_BLOQUE = ("else", "until") + SIGUIENTE_SENTENCIA
SIGUIENTE_EXPRESION = (';', ')')
SIGUIENTE_EXPRESION_SIMPLE = PRIMERO_RELACION + PRIMERO_SUMA_OP + SIGUIENTE_EXPRESION
SIGUIENTE_FACTOR = PRIMERO_MULT_OP + SIGUIENTE_EXPRESION_SIMPLE

PROGRAMA = ("main",)
LISTA_DECLARACION = (PRIMERO_TIPO, SIGUIENTE_LISTA_DECLARACION)
DECLARACION = (PRIMERO_TIPO, SIGUIENTE_LISTA_VARIABLES)
TIPO = (PRIMERO_TIPO,)
LISTA_VARIABLES = (SIGUIENTE_LISTA_VARIABLES,)
LISTA_SENTENCIAS = (PRIMERO_SENTENCIA, SIGUIENTE_LISTA_SENTENCIAS)
SENTENCIA = (PRIMERO_SENTENCIA, SIGUIENTE_SENTENCIA)
SELECCION = (("if",), SIGUIENTE_SELECCION)
ITERACION = (("while",), SIGUIENTE_ITERACION)
REPETICION = (("repeat",), SIGUIENTE_REPETICION)
SENT_CIN = (("cin",), SIGUIENTE_CIN)
SENT_COUT = (("cout",), SIGUIENTE_COUT)
BLOQUE = (('{',), SIGUIENTE_BLOQUE)
ASIGNACION = (SIGUIENTE_SENTENCIAS,)
EXPRESION = (PRIMERO_EXPRESION_SIMPLE, SIGUIENTE_EXPRESION)
RELACION = (PRIMERO_RELACION, PRIMERO_EXPRESION_SIMPLE)
EXPRESION_SIMPLE = (PRIMERO_EXPRESION_SIMPLE, SIGUIENTE_EXPRESION_SIMPLE)
SUMA_OP = (PRIMERO_SUMA_OP, PRIMERO_EXPRESION_SIMPLE)
TERMINO = (PRIMERO_EXPRESION_SIMPLE, SIGUIENTE_FACTOR)
MULT_OP = (PRIMERO_MULT_OP, PRIMERO_EXPRESION_SIMPLE)
FACTOR = (PRIMERO_EXPRESION_SIMPLE, SIGUIENTE_FACTOR)

PATRON_IDENTIFICADOR = re.compile('^[A-Za-z]\w*$')
PATRON_NUMERO = re.compile('^\d+(\.\d+)?$')
LISTA_PATRONES = [PATRON_IDENTIFICADOR, PATRON_NUMERO]

ID_NUM = "identificador numero"
ID = "identificador"
NUM = "numero"

ARBOL_TXT = "arbol.txt"
ARBOL_DOT = "arbol.dot"
ARBOL_PNG = "arbol.png"

ERROR_FUERA = "Error: Programa termina antes"
SEPARADOR_LLAVE = '#'

class MiNodo(Node):
    separator = "|"


with open(sys.argv[1], "r") as f:
    lineas = f.read().splitlines()

i = 0
token = ln_col = ""

errores = []

directorio_sintactico = os.path.dirname(os.path.realpath(__file__)) + os.path.sep + "Sintactico"


def avanzar():
    global i
    if i < len(lineas) - 1:
        i += 1
        actualizar_token()

def actualizar_token():
    global token, ln_col
    linea_separada = separate(lineas[i])
    token = linea_separada[0]
    ln_col = linea_separada[1]


def separate(linea):
    return linea.split(' ', 1)


def matchmaking(token_esperado):
    if token == token_esperado:
        print "token correcto: " + token + " " + ln_col
        avanzar()
    else:
        error()


def error():
    if errores:
        if errores[-1] != "Error sintactico en la posicion: " + ln_col:
            errores.append("Error sintactico en la posicion: " + ln_col)
            print "Error sintactico en la posicion: " + ln_col
    else:
        errores.append("Error sintactico en la posicion: " + ln_col)
        print "Error sintactico en la posicion: " + ln_col


def checa_patron(patron):
    if ID_NUM == patron:
        return any(r.match(token) for r in LISTA_PATRONES) and token not in RESERVADAS
    elif ID == patron:
        return PATRON_IDENTIFICADOR.match(token) and token not in RESERVADAS
    elif NUM == patron:
        return PATRON_NUMERO.match(token)


def scanto(synchset=(), patron_follow=""):
    if synchset or patron_follow:
        while token not in synchset and not checa_patron(patron_follow) and i < len(lineas) - 1:
            avanzar()


def check_point(firstset=(), patron_first="", followset=(), patron_follow=""):
    if firstset:
        if token not in firstset:
            if patron_first:
                if not checa_patron(patron_first):
                    error()
                    scanto(firstset + followset, patron_follow)
            else:
                error()
                scanto(firstset + followset, patron_follow)
    elif patron_first:
        if not checa_patron(patron_first):
            error()
            scanto(firstset + followset, patron_follow)


# GRAMATICA
def programa():
    temp = MiNodo("")

    if token == "main":
        temp.name = token
    matchmaking("main")

    matchmaking('{')

    nodo_declaraciones = lista_declaracion()
    if nodo_declaraciones:
        nodo_declaraciones.parent = temp

    nodo_sentencias = lista_sentencias()
    if nodo_sentencias:
        nodo_sentencias.parent = temp

    indice_final = i
    matchmaking('}')

    if indice_final != i:
        errores.append(ERROR_FUERA)
        print ERROR_FUERA

    return temp


def lista_declaracion():
    if token in LISTA_DECLARACION[0]:
        check_point(LISTA_DECLARACION[0], followset=LISTA_DECLARACION[1], patron_follow=ID)
        temp = MiNodo("ld")
        while token in LISTA_DECLARACION[0]:
            declaracion().parent = temp
            matchmaking(';')
        check_point(LISTA_DECLARACION[1], ID, LISTA_DECLARACION[0])
        return temp


def declaracion():
    check_point(DECLARACION[0], followset=DECLARACION[1])
    temp = MiNodo("")
    if token in DECLARACION[0]:
        tipo_temporal = token
        ln_col_temporal = ln_col
        matchmaking(token)
        temp = lista_variables()
        temp.name = tipo_temporal + SEPARADOR_LLAVE + ln_col_temporal
        check_point(DECLARACION[1], followset=DECLARACION[0])
    return temp


def lista_variables():
    check_point(patron_first=ID, followset=LISTA_VARIABLES[0])
    temp = MiNodo("")
    if checa_patron(ID):
        if checa_patron(ID):
            MiNodo(token, parent=temp)
            matchmaking(token)
        else:
            error()
        while token == ',':
            matchmaking(',')
            if checa_patron(ID):
                MiNodo(token, parent=temp)
                matchmaking(token)
            else:
                error()
        check_point(LISTA_VARIABLES[0], patron_follow=ID)
    return temp


def lista_sentencias():
    if token in LISTA_SENTENCIAS[0] or checa_patron(ID):
        check_point(LISTA_SENTENCIAS[0], ID, LISTA_SENTENCIAS[1])
        temp = MiNodo("ls" + SEPARADOR_LLAVE + ln_col)
        if token in LISTA_SENTENCIAS[0] or checa_patron(ID):
            sentencia().parent = temp
            while token in LISTA_SENTENCIAS[0] or checa_patron(ID):
                sentencia().parent = temp
            check_point(LISTA_SENTENCIAS[1], followset=LISTA_SENTENCIAS[0], patron_follow=ID)
        return temp


def sentencia():
    check_point(SENTENCIA[0], ID, SIGUIENTE_SENTENCIAS, ID)
    temp = MiNodo("")
    if token not in SENTENCIA[1]:
        if token == "if":
            temp = seleccion()
        elif token == "while":
            temp = iteracion()
        elif token == "repeat":
            temp = repeticion()
        elif token == "cin":
            temp = sent_cin()
        elif token == "cout":
            temp = sent_cout()
        elif token == '{':
            temp = bloque()
        elif checa_patron(ID):
            temp = asignacion()
        check_point(SIGUIENTE_SENTENCIAS, ID, SENTENCIA[0], ID)
    return temp


def seleccion():
    check_point(SELECCION[0], followset=SIGUIENTE_SENTENCIAS, patron_follow=ID)
    temp = MiNodo("")
    if token in SELECCION[0]:
        temp = MiNodo(token + SEPARADOR_LLAVE + ln_col)
        matchmaking("if")
        matchmaking('(')
        expresion().parent = temp
        matchmaking(')')
        matchmaking("then")
        bloque().parent = temp
        if token == "else":
            matchmaking("else")
            bloque().parent = temp
        check_point(SIGUIENTE_SENTENCIAS, ID, SELECCION[0])
    return temp


def iteracion():
    check_point(ITERACION[0], followset=SIGUIENTE_SENTENCIAS, patron_follow=ID)
    temp = MiNodo("")
    if token in ITERACION[0]:
        temp = MiNodo(token + SEPARADOR_LLAVE + ln_col)
        matchmaking("while")
        matchmaking('(')
        expresion().parent = temp
        matchmaking(')')
        bloque().parent = temp
        check_point(SIGUIENTE_SENTENCIAS, ID, ITERACION[0])
    return temp


def repeticion():
    check_point(REPETICION[0], followset=SIGUIENTE_SENTENCIAS, patron_follow=ID)
    temp = MiNodo("")
    if token in REPETICION[0]:
        temp = MiNodo(token + SEPARADOR_LLAVE + ln_col)
        matchmaking("repeat")
        bloque().parent = temp
        matchmaking("until")
        matchmaking('(')
        expresion().parent = temp
        matchmaking(')')
        matchmaking(';')
        check_point(SIGUIENTE_SENTENCIAS, ID, REPETICION[0])
    return temp


def sent_cin():
    check_point(SENT_CIN[0], followset=SIGUIENTE_SENTENCIAS, patron_follow=ID)
    temp = MiNodo("")
    if token in SENT_CIN[0]:
        matchmaking("cin")
        if checa_patron(ID):
            temp = MiNodo("cin: " + token + SEPARADOR_LLAVE + ln_col)
            matchmaking(token)
        else:
            error()
        matchmaking(';')
        check_point(SIGUIENTE_SENTENCIAS, ID, SENT_CIN[0])
    return temp


def sent_cout():
    check_point(SENT_COUT[0], followset=SIGUIENTE_SENTENCIAS, patron_follow=ID)
    temp = MiNodo("")
    if token in SENT_COUT[0]:
        temp = MiNodo(token + SEPARADOR_LLAVE + ln_col)
        matchmaking("cout")
        expresion().parent = temp
        matchmaking(';')
        check_point(SIGUIENTE_SENTENCIAS, ID, SENT_COUT[0])
    return temp


def bloque():
    check_point(BLOQUE[0], followset=SIGUIENTE_SENTENCIAS + ("else", "until"), patron_follow=ID)
    temp = MiNodo("")
    if token in BLOQUE[0]:
        matchmaking('{')
        temp = lista_sentencias()
        matchmaking('}')
        check_point(SIGUIENTE_SENTENCIAS + ("else", "until"), ID, BLOQUE[0])
    return temp


def asignacion():
    check_point(patron_first=ID, followset=SIGUIENTE_SENTENCIAS, patron_follow=ID)
    temp = MiNodo("")
    if checa_patron(ID):
        if checa_patron(ID):
            temp = MiNodo("Asign: " + token + SEPARADOR_LLAVE + ln_col)
            matchmaking(token)
        else:
            error()
        matchmaking(":=")
        expresion().parent = temp
        matchmaking(';')
        check_point(SIGUIENTE_SENTENCIAS, ID, patron_follow=ID)
    return temp


def expresion():
    check_point(EXPRESION[0], ID_NUM, EXPRESION[1])
    temp = MiNodo("")
    if token not in EXPRESION[1]:
        temp = expresion_simple()
        if token in RELACION[0]:
            newtemp = MiNodo(token)
            matchmaking(token)
            temp.parent = newtemp
            expresion_simple().parent = newtemp
            temp = newtemp
        check_point(EXPRESION[1], followset=EXPRESION[0], patron_follow=ID_NUM)
    return temp


def expresion_simple():
    check_point(EXPRESION_SIMPLE[0], ID_NUM, EXPRESION_SIMPLE[1])
    temp = MiNodo("")
    if token not in EXPRESION_SIMPLE[1]:
        temp = termino()
        while token in SUMA_OP[0]:
            newtemp = MiNodo(token)
            matchmaking(token)
            temp.parent = newtemp
            termino().parent = newtemp
            temp = newtemp
        check_point(EXPRESION_SIMPLE[1], followset=EXPRESION_SIMPLE[0], patron_follow=ID_NUM)
    return temp


def termino():
    check_point(TERMINO[0], ID_NUM, TERMINO[1])
    temp = MiNodo("")
    if token not in TERMINO[1]:
        temp = factor()
        while token in MULT_OP[0]:
            newtemp = MiNodo(token)
            matchmaking(token)
            temp.parent = newtemp
            factor().parent = newtemp
            temp = newtemp
        check_point(TERMINO[1], followset=TERMINO[0], patron_follow=ID_NUM)
    return temp


def factor():
    check_point(FACTOR[0], ID_NUM, FACTOR[1])
    temp = MiNodo("")
    if token not in FACTOR[1]:
        if token == '(':
            matchmaking('(')
            temp = expresion()
            matchmaking(')')
        elif checa_patron(NUM):
            temp = MiNodo(token)
            matchmaking(token)
        elif checa_patron(ID):
            temp = MiNodo(token)
            matchmaking(token)
        else:
            error()
        check_point(FACTOR[1], followset=FACTOR[0], patron_follow=ID_NUM)
    return temp


# PROGRAMA PRINCIPAL
actualizar_token()
raiz = programa()

if not os.path.exists(directorio_sintactico):
    os.makedirs(directorio_sintactico)

with open(directorio_sintactico + os.path.sep + ARBOL_TXT, "w") as archivo_arbol:
    archivo_arbol.write(str(RenderTree(raiz, style=AsciiStyle())))

if os.name == 'posix':
    RenderTreeGraph(raiz, nodeattrfunc=lambda node: "shape = box").to_picture(directorio_sintactico + os.path.sep + ARBOL_PNG)
elif os.name == 'nt':
    RenderTreeGraph(raiz, nodeattrfunc=lambda node: "shape = box").to_dotfile(directorio_sintactico + os.path.sep + ARBOL_DOT)
    comando = "dot " + directorio_sintactico + os.path.sep + ARBOL_DOT + " -T png -o " + directorio_sintactico + os.path.sep + ARBOL_PNG
    startupinfo = subprocess.STARTUPINFO()
    startupinfo.dwFlags |= subprocess.STARTF_USESHOWWINDOW
    subprocess.call(comando, startupinfo=startupinfo)

with open(directorio_sintactico + os.path.sep + "errores_sintacticos.txt", "w") as archivo_errores_sintacticos:
    for error in errores:
        archivo_errores_sintacticos.write(error + '\n')