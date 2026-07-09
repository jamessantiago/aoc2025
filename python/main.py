import importlib
from pathlib import Path


def run_next():
    files = [f.name for f in Path('solutions').glob('*.py')]
    next_solution = next(iter(sorted(files, reverse=True)))
    next_solution = next_solution.replace('.py', '')
    solution = importlib.import_module(f"solutions.{next_solution}")
    solveFn = getattr(solution, 'solveB', None) or getattr(solution, 'solveA', None)
    if solveFn:
        solveFn()
    else:
        print('No solution found')

if __name__ == '__main__':
    run_next()

