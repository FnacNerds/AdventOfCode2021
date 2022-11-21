let input = await Deno.readTextFile("input.txt", "utf-8");
let array = input.split(",");
let count = 0;
let map = {};
for (let i = 0; i < array.length; i++) {
  let e = Number(array[i]);
  if (!map[e]) {
    map[e] = 1;
  } else {
    map[e] += 1;
  }
}
while (count < 257) {
  let mapTemp = {};
  mapTemp[8] = map[0];
  mapTemp[6] = map[0];
  mapTemp[7] = map[8];
  for (let i = 1; i <= 8; i++) {
    if (i == 0) console.log(map[i]);
    mapTemp[i - 1] = map[i];
  }
  if (Number.isInteger(map[0])) {
    if (Number.isInteger(mapTemp[6])) {
      mapTemp[6] += map[0];
    } else {
      mapTemp[6] = map[0];
    }
  }
  map = mapTemp;
  count++;
}
map[8] = 0;
console.log(Object.values(map).reduce((a, b) => a + b, 0));
