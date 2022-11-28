function compute(inputRaw) {
  const inputLines = inputRaw.split("\n");
  let total1 = 0;
  let total2 = 0;
  for (let i = 0; i < inputLines.length; i++) {
    const args = inputLines[i].split("|");
    const sample = args[0].match(/\S+/g);
    const output = args[1].match(/\S+/g);
    total1 += output.filter((o: string | any[]) =>
      [2, 3, 4, 7].includes(o.length)
    ).length;
    // compute wiring
    let wiring = {
      a: "",
      b: "",
      c: "",
      d: "",
      e: "",
      f: "",
      g: "",
    };
    sample.sort((a, b) => a.length - b.length);
    let count = [...sample.join("")].reduce((a, e) => {
      a[e] = a[e] ? a[e] + 1 : 1;
      return a;
    }, {});
    // console.log(count);
    wiring["f"] = Object.keys(count).filter((o) => count[o] === 9)[0];
    wiring["e"] = Object.keys(count).filter((o) => count[o] === 4)[0];
    wiring["b"] = Object.keys(count).filter((o) => count[o] === 6)[0];
    for (let j = 0; j < sample.length; j++) {
      const element = sample[j].split("");
      switch (element.length) {
        case 2:
          wiring["c"] = element.filter((o) => o !== wiring["f"])[0];
          wiring["a"] = Object.keys(count).filter(
            (o) => count[o] === 8 && o !== wiring["c"]
          )[0];
          break;
        case 4:
          wiring["d"] = element.filter(
            (o) => o !== wiring["c"] && o !== wiring["f"] && o !== wiring["b"]
          )[0];
          wiring["g"] = Object.keys(count).filter(
            (o) => count[o] === 7 && o !== wiring["d"]
          )[0];
          break;
      }
    }
    // console.log(wiring);

    let res = "";
    for (let i = 0; i < output.length; i++) {
      const e = output[i];
      let trans = "";
      [...e].forEach(
        (l) => (trans += Object.keys(wiring).filter((k) => wiring[k] === l)[0])
      );
      let t2 = trans.split("").sort().join("");
      switch (t2) {
        case "cf":
          res += "1";
          continue;
        case "acf":
          res += "7";
          continue;
        case "bcdf":
          res += "4";
          continue;
        case "abdfg":
          res += "5";
          continue;
        case "acdeg":
          res += "2";
          continue;
        case "acdfg":
          res += "3";
          continue;
        case "abcefg":
          res += "0";
          continue;
        case "abcdfg":
          res += "9";
          continue;
        case "abdefg":
          res += "6";
          continue;
        case "abcdefg":
          res += "8";
          continue;
      }
    }
    total2 += Number(res);
  }
  return { total1, total2 };
}

const inputRaw = await Deno.readTextFile("input.txt", "utf-8");
// const inputRaw = await Deno.readTextFile("sample_input.txt", "utf-8");

const { total1, total2 } = compute(inputRaw);
console.assert(total1 === 294);
console.log(total2);
