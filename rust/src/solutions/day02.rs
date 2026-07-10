use std::cmp::{max, min};
use std::collections::HashSet;
use std::fs;

fn solve_a(pairs: Vec<(&str, &str)>) {
    let mut total :i64 = 0;
    for (pair_a, pair_b) in pairs {
        let start = pair_a.parse::<i64>().unwrap();
        let end = pair_b.parse::<i64>().unwrap();
        let max_len = pair_b.len() as u32;
        for i in (2..=max_len).step_by(2) {
            let h = i / 2;
            let factor = 10_i64.pow(h) + 1;
            let min_p = 10_i64.pow(h - 1);
            let max_p = 10_i64.pow(h) - 1;
            let p_low = max(min_p, (start + factor - 1) / factor);
            let p_high = min(max_p, end / factor);
            if p_low > p_high {
                continue;
            }

            let count = p_high - p_low + 1;
            total += factor * (p_low + p_high) * count / 2;
        }
    }
    println!("{}", total);
}

fn solve_b(pairs: Vec<(&str, &str)>) {
    let mut ids: HashSet<i64> = HashSet::new();
    for pair in pairs {
        let start = pair.0.parse::<i64>().unwrap();
        let end = pair.1.parse::<i64>().unwrap();
        let max_len = pair.1.len() as u32;
        for i in 2..=max_len {
            for j in 1..i {
                if i % j != 0 {
                    continue;
                }
                let r = i / j;
                if r < 2 {
                    continue;
                }

                let mut factor: i64 = 0;
                let mut term: i64 = 1;
                for _ in 0..r {
                    factor += term;
                    term *= 10_i64.pow(j as u32);
                }

                let min_p = 10_i64.pow(j - 1);
                let max_p = 10_i64.pow(j) - 1;
                let p_low = max(min_p, (start + factor - 1) / factor);
                let p_high = min(max_p, end / factor);
                for p in p_low..=p_high {
                    ids.insert(factor * p as i64);
                }
            }
        }
    }

    let mut total: i64 = 0;
    for id in ids.iter() {
        total += id;
    }
    println!("{:?}", total);
}

pub fn solve() {
    let text = fs::read_to_string("src/inputs/day02.txt")
        .unwrap();
    let pairs = text
        .split(',')
        .map(|s| s.split_once('-').unwrap())
        .collect::<Vec<(&str, &str)>>();
    let pairs_cpy = pairs.clone();
    solve_a(pairs);
    solve_b(pairs_cpy);
}