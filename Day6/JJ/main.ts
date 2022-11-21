let input = await Deno.readTextFile("input.txt", "utf-8");
let array = input.split(",");
let count = 0;
while (count < 81) {
  let resets = 0;
  for (let i = 0; i < array.length; i++) {
    let e = Number(array[i]);
    if (e > 0) e--;
    else if (e === 0) {
      e = 6;
      resets++;
    }
    array[i] = e;
  }
  let initLength = array.length;
  for (let j = 0; j < resets; j++) {
    array[initLength + j] = "8";
  }
  count++;
}
console.log(array.length);
