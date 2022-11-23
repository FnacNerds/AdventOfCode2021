const inputRaw = await Deno.readTextFile("input.txt", "utf-8");
const inputLines = inputRaw.split("\n");

let total = 0;
for (let i = 0; i < inputLines.length; i++) {
  const args = inputLines[i].split("|");
  //   const sample = args[0].split(" ");
  const output = args[1].match(/\S+/g);
  total += output.filter((o: string | any[]) =>
    [2, 3, 4, 7].includes(o.length)
  ).length;
}

console.log(total);
