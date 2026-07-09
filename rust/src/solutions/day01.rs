use std::fs;

fn solve_a(lines: Vec<String>) {
    let mut dial = 50;
    let mut zeros = 0;
    for (_, line) in lines.iter().enumerate()
    {
        if line == "" {
            continue;
        }
        let distance = &line[1..].parse::<i32>().unwrap();
        if line.chars().nth(0).unwrap() == 'L' {
            dial -= distance;
            if dial < 0 {
                dial += 100;
            }
            dial %= 100;
        } else {
            dial += distance;
            dial %= 100;
        }
        if dial == 0 {
            zeros += 1;
        }
    }
    println!("Answer A: {}", zeros);
}

fn solve_b(lines: Vec<String>) {
    let mut dial = 50;
    let mut zeros = 0;
    for (_, line) in lines.iter().enumerate() {
        if line == "" {
            continue;
        }
        let distance = &line[1..].parse::<i32>().unwrap();
        if line.chars().nth(0).unwrap() == 'L' {
            zeros += floor_div(dial - 1, 100) - floor_div(dial - distance - 1, 100);
            dial -= distance;
            dial %= 100;
            if dial < 0 {
                dial += 100;
            }
        } else {
            zeros += (dial + distance) / 100 - dial / 100;
            dial += distance;
            dial %= 100;
        }
    }
    println!("Answer B: {}", zeros);
}

fn floor_div(a: i32, b: i32) -> i32 {
    let mut q = a / b;
    if (a ^ b) < 0 && a % b != 0 {
        q -= 1;
    }
    return q;
}

pub fn solve() {
    let lines = fs::read_to_string("src/inputs/day01.txt")
        .unwrap()
        .lines()
        .map(String::from)
        .collect::<Vec<String>>();
    solve_b(lines);
}