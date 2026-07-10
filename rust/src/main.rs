mod solutions;

fn main() {
    let days: Vec<(&str, fn())> = vec![
        ("day01", solutions::day01::solve),
        ("day02", solutions::day02::solve),
    ];

    let latest = days.last();
    latest.unwrap().1();
}
