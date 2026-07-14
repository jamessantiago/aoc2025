package day01

import (
	"fmt"
	"os"
	"strconv"
	"strings"
)

func Solve() {
	text, _ := os.ReadFile("inputs/day01.txt")
	lines := strings.Split(string(text), "\n")

	solveB(lines)
}

func solveA(lines []string) {
	dial := 50
	zeros := 0

	for _, line := range lines {
		distance, _ := strconv.Atoi(line[1:])
		if line[0] == 'L' {
			dial -= distance
			if dial < 0 {
				dial += 100
			}
			dial %= 100
		} else {
			dial += distance
			dial %= 100
		}
		if dial == 0 {
			zeros++
		}
	}
	fmt.Println(zeros)
}

func solveB(lines []string) {
	dial := 50
	zeros := 0
	for _, line := range lines {
		distance, _ := strconv.Atoi(line[1:])
		if line[0] == 'L' {
			zeros += floor_div(dial-1, 100) - floor_div(dial-distance-1, 100)
			dial -= distance
			dial %= 100
			if dial < 0 {
				dial += 100
			}
		} else {
			zeros += (dial+distance)/100 - dial/100
			dial += distance
			dial %= 100
		}
	}
	fmt.Println(zeros)
}

func floor_div(a int, b int) int {
	var q = a / b
	if (a^b) < 0 && a%b != 0 {
		q--
	}
	return q
}
