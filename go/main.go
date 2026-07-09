package main

import (
	"fmt"
	"os"

	"aoc2025/solutions"
)

func main() {
	fn := solutions.Last()
	if fn == nil {
		fmt.Println("no solutions found")
		os.Exit(1)
	}
	fn()
}