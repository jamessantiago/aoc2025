package day02

import (
	"maps"
	"math"
	"os"
	"strconv"
	"strings"
)

type Pair struct {
	First  string
	Second string
}

func Solve() {
	text, _ := os.ReadFile("inputs/day02.txt")
	input := strings.Split(string(text), ",")
	pairs := make([]Pair, len(input))
	for i, s := range input {
		split := strings.Split(s, "-")
		pairs[i] = Pair{split[0], split[1]}
	}

	solveB(pairs)
}

func solveA(pairs []Pair) {
	var total int64
	for _, pair := range pairs {
		start, _ := strconv.ParseInt(pair.First, 10, 64)
		end, _ := strconv.ParseInt(pair.Second, 10, 64)
		maxLen := len(pair.Second)
		for i := 2; i <= maxLen; i += 2 {
			h := i / 2
			factor := int64(math.Pow10(h) + 1)
			minP := int64(math.Pow10(h - 1))
			maxP := int64(math.Pow10(h) - 1)
			pLow := max(minP, (start+factor-1)/factor)
			pHigh := min(maxP, end/factor)
			if pLow > pHigh {
				continue
			}

			count := pHigh - pLow + 1
			total += factor * (pLow + pHigh) * count / 2
		}
	}
	println(total)
}

func solveB(pairs []Pair) {
	ids := make(map[int64]struct{})
	for _, pair := range pairs {
		start, _ := strconv.ParseInt(pair.First, 10, 64)
		end, _ := strconv.ParseInt(pair.Second, 10, 64)
		maxLen := len(pair.Second)
		for i := 2; i <= maxLen; i += 2 {
			for j := 1; j < i; j++ {
				if i%j != 0 {
					continue
				}
				r := i / j
				if r < 2 {
					continue
				}

				var factor, term int64
				factor = 0
				term = 1
				for t := 0; t < r; t++ {
					factor += term
					term *= int64(math.Pow10(j))
				}

				minP := int64(math.Pow10(j - 1))
				maxP := int64(math.Pow10(j) - 1)
				pLow := max(minP, (start+factor-1)/factor)
				pHigh := min(maxP, end/factor)
				for p := pLow; p <= pHigh; p++ {
					ids[p*factor] = struct{}{}
				}
			}
		}
	}

	var total int64
	for id := range maps.Keys(ids) {
		total += id
	}
	println(total)
}
