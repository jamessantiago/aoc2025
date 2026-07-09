package solutions

type registryEntry struct {
	Day int
	Fn  func()
}

var days []registryEntry

func Register(day int, fn func()) {
	days = append(days, registryEntry{Day: day, Fn: fn})
}

func Last() func() {
	if len(days) == 0 {
		return nil
	}
	best := days[0]
	for _, e := range days[1:] {
		if e.Day > best.Day {
			best = e
		}
	}
	return best.Fn
}