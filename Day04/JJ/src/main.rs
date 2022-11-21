#![allow(dead_code, unused)]
use std::collections::HashMap;
use std::fs;
use std::io::{BufRead, BufReader};

fn main() -> std::io::Result<()> {
    let mut reader = BufReader::new(fs::File::open("input.txt")?);
    let mut line = String::new();
    let mut count = 0;
    reader.read_line(&mut line)?;

    let draws = line
        .trim_end()
        .split(",")
        .map(|s| s.parse::<u8>().unwrap())
        .collect::<Vec<u8>>();
    dbg!(&draws);
    let max = draws.iter().max();
    match max {
        Some(max) => println!("Min value: {}", max),
        None => println!("Vector is empty"),
    }

    let numbers = (0..99)
        .map(|c| (c, Vec::new()))
        .collect::<HashMap<_, Vec<u8>>>();
    // dbg!(numbers);
    // let mut previous:i32 = line.trim_end().parse().unwrap();
    // println!("First line is {}", lines);
    let mut grids: Vec<Vec<u8>> = Vec::new();
    // let mut count: u8 = 1;
    loop {
        let mut buff = String::new();
        reader.read_line(&mut buff)?;
        if buff == "" {
            println!("{}", &grids.len());
            dbg!(&grids[0]);
            return Ok(());
        }

        if buff.trim().is_empty() {
            continue;
        }

        grids.push(
            buff.split_whitespace()
                .map(|s| s.parse::<u8>().unwrap())
                .collect::<Vec<u8>>(),
        );
        // count += 1;
    }
}
