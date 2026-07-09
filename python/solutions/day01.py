from pathlib import Path

_input: str = ''

def load():
    global _input
    day = Path(__file__).name.replace('.py', '')
    _input = Path(f'inputs/{day}.txt').read_text()

def solveA():
    global _input
    load()
    dial = 50
    zeros = 0
    lines = _input.splitlines()
    for line in lines:
        if not line:
            continue

        distance = int(line[1:])
        if line[0] == 'L':
            dial -= distance
            if (dial < 0):
                dial += 100
            dial %= 100
        else:
            dial += distance
            dial %= 100

        if dial == 0:
            zeros += 1

    print(zeros)

def solveB():
    global _input
    load()

    dial = 50
    zeros = 0
    lines = _input.splitlines()

    for line in lines:
        if not line:
            continue

        distance = int(line[1:])
        if line[0] == 'L':
            zeros += floor_div(dial - 1, 100) - floor_div(dial - distance - 1, 100)
            dial -= distance
            dial %= 100
            if dial < 0:
                dial += 100
        else:
            zeros += (dial + distance) // 100 - dial // 100
            dial += distance
            dial %= 100

    print(zeros)
def floor_div(a: int, b: int):
    q = int(a / b)
    if (a ^ b) < 0 and a % b != 0:
        q -= 1
    return q

def floor_div_alt(a: int, b: int):
    q = a // b
    if (a ^ b) < 0 and a % b != 0:
        q -= 1
    return q

def floor_div_test(a: int, b: int):
    print(floor_div(a, b))
    print(floor_div_alt(a, b))