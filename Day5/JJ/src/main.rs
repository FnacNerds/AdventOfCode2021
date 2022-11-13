#![allow(dead_code, unused)]
use regex::Regex;
use std::collections::HashMap;
use std::fs;
use std::io::{BufRead, BufReader};

fn main() -> std::io::Result<()> {
    let mut reader = BufReader::new(fs::File::open("../input.txt")?);
    // let mut line = String::new();
    // reader.read_line(&mut line)?;

    let regex: Regex = Regex::new(r"(\d+),(\d+) -> (\d+),(\d+)").unwrap();
    let mut map: HashMap<(i32, i32), i32> = HashMap::with_capacity(1000000);
    let mut count = 0;
    loop {
        let mut buff = String::new();
        reader.read_line(&mut buff)?;
        // dbg!(&buff);
        if count > 1 {
            break;
        }
        if buff == "" {
            break;
        }
        
        if buff.trim().is_empty() {
            println!("TOTOT");
            continue;
        }
        &buff.trim_end();
        let mut captures = regex.captures_iter(&buff);
        println!("TOTOTferfref");
            // println!("a: {} b: {} c: {} d: {}", cap.get(1), cap.get(2), cap.get(3), cap.get(4));
        // if let Some(cap) = iter.next() {
            for cap in captures {
                dbg!(cap.get(2).unwrap().as_str().parse::<i32>().unwrap());
                let mut x0: i32 = cap.get(1).unwrap().as_str().parse::<i32>().unwrap();
                let mut x1: i32 = cap.get(3).unwrap().as_str().parse::<i32>().unwrap();
                let mut y0: i32 = cap.get(2).unwrap().as_str().parse::<i32>().unwrap();
                let mut y1: i32 = cap.get(4).unwrap().as_str().parse::<i32>().unwrap();
                println!("a: {} b: {}", x0, x1);
                // if (x0 != x1 && y0 != y1) {
                //     continue;
                // }
                if (x0 - x1 != 0 && y0 - y1 != 0) {
                    if ((x0 - x1).abs() != (y0 - y1).abs()) {
                        println!(" not 45 degrees {} {} {} {} ", x0, x1, y0, y1);
                        continue;
                    }
                    else {
                        // println!("45 degrees {} {} {} {} ", x0, x1, y0, y1);
                        let mut range_x = if x0 > x1 { x1..=x0 } else { x0..=x1 };
                        let mut range_y = if y0 > y1 { y1..=y0 } else { y0..=y1 };
                        loop {
                            match &mut range_x.next() {
                                Some(x) => {
                                    match &mut range_y.next() {
                                        Some(y) => {
                                            println!("{} {}",x, y);
                                            map.entry((*x,*y)).and_modify(|counter| *counter += 1).or_insert(1);
                                        },
                                        None => { break }
                                    }
                                },
                                None => { break }
                            }
                        }
                        break;
                    }
                }
                else {
                    if (x0 > x1) {
                        let xtemp = x1;
                        x1 = x0;
                        x0 = xtemp;
                    }
                    if (y0 > y1) {
                        let ytemp = y1;
                        y1 = y0;
                        y0 = ytemp;
                    }

                    for i in x0..=x1 {
                        let range_y = if y0 > y1 { y1..=y0 } else { y0..=y1 };
                        for j in y0..=y1 {
                            map.entry((i,j)).and_modify(|counter| *counter += 1).or_insert(1);
                            // println!("i {}", i);
                            // println!("j {}", j);
                        }
                    }
                }
            }
        
        count += 1;
    }
    let mut result = 0;
    for (key, value) in map.clone().into_iter() {
        println!("{:#?} {:#?}", key, value);
        if value > 1 {
           result += 1;
        }
    }
    // // let result = map.clone().into_iter().filter_map(|(key, value)| value > 1).collect().len(); 
    println!("a: {}", result);
    return Ok(());
}
