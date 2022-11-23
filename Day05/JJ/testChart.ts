import Chart from "npm:chart.js@^4/auto";
import { getRelativePosition } from "npm:chart.js@^4/helpers";

import { JSDOM } from "npm:jsdom";

const {
  window: { document },
} = new JSDOM(`<!DOCTYPE html><body><div id="myChart"></div></body>`, {
  url: "https://example.com/",
  referrer: "https://example.org/",
  contentType: "text/html",
  storageQuota: 10000000,
});
const ctx = document.getElementById("myChart");

const chart = new Chart(ctx, {
  type: "line",
  data: [0, 1, 2, 3, 4, 5],
  options: {
    onClick: (e) => {
      const canvasPosition = getRelativePosition(e, chart);

      // Substitute the appropriate scale IDs
      const dataX = chart.scales.x.getValueForPixel(canvasPosition.x);
      const dataY = chart.scales.y.getValueForPixel(canvasPosition.y);
    },
  },
});

console.log(chart);
