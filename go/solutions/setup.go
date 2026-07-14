package solutions

import (
	"aoc2025/solutions/day01"
	"aoc2025/solutions/day02"
)

func init() {
	Register(1, day01.Solve)
	Register(2, day02.Solve)
}
