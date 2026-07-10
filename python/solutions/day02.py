from pathlib import Path

_pairs: list = []

def load():
    global _pairs
    day = Path(__file__).name.replace('.py', '')
    text = Path(f'inputs/{day}.txt').read_text()
    _pairs = list(map(lambda a: a.split('-'), text.split(',')))

def solveA():
    load()
    total = 0
    for pair in _pairs:
        start = int(pair[0])
        end = int(pair[1])
        max_len = len(pair[1])

        for i in range(2, max_len + 1, 2):
            h = int(i / 2)
            factor = 10**h + 1
            min_p = 10**(h - 1)
            max_p = 10**h - 1
            p_low = max(min_p, int((start + factor - 1) / factor))
            p_high = min(max_p, int(end / factor))
            if p_low > p_high:
                continue

            count = p_high - p_low + 1
            total += int(factor * (p_low + p_high) * count / 2)

    print(total)

def solveB():
    load()
    ids = set()
    for pair in _pairs:
        start = int(pair[0])
        end = int(pair[1])
        max_len = len(pair[1])
        for i in range(2, max_len + 1):
            for j in range(1, i):
                if i % j != 0:
                    continue
                r = int(i / j)
                if r < 2:
                    continue

                factor = 0
                term = 1
                for t in range(0, r):
                    factor += term
                    term *= 10**j

                min_p = 10**(j - 1)
                max_p = 10**j - 1
                p_low = max(min_p, int((start + factor - 1) / factor))
                p_high = min(max_p, int(end / factor))
                for p in range(p_low, p_high + 1):
                    ids.add(p * factor)

    total = 0
    for id_val in ids:
        total += id_val
    print(total)