import fs from "fs";
import axios from "axios";

const getData = async (params) => {
  let flightData = [];
  for (let i = 0; i < 1; i++) {
    let offset = 0;
    if (i > 0) {
      offset = i * 100;
    }

    axios
      .get("http://api.aviationstack.com/v1/flights", { params })
      .then((response) => {
        const data = response.data;
        let newFlightData = data.data;
        flightData.push(...newFlightData);

        return flightData;
      })
      .catch((error) => {
        console.log(error);
      });
  }
};

let params = {
  access_key: "18d9ac328be6cdbe249ab5f8523e9de8",
};

await getData(params).then((res) => {
  console.log("res", res);
  // fs.writeFile("flightData.json", res, function (err) {
  //   if (err) {
  //     console.log(err);
  //   }
  // });
});
