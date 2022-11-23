const input = await Deno.readTextFile("input.txt", "utf-8");
const array = input.split(",").map((m) => Number(m));
const min = Math.min(...array);
const max = Math.max(...array);

let fuel = Infinity;
for (let i = min; i < max; i++) {
  let temp = 0;
  for (let j = 0; j < array.length; j++) {
    const diff = Math.abs(array[j] - i);
    temp += (diff * (diff + 1)) / 2;
  }
  if (temp < fuel) fuel = temp;
}
console.log(fuel);
console.log(max);
