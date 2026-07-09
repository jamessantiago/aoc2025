mod solutions;

fn main() {
    let days = vec![
        ("day01", solutions::day01::solve),
    ];

    let latest = days.last();
    latest.unwrap().1();
}
