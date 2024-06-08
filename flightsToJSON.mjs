import fs from "fs";
import axios from "axios";

const getData = async (url, params = {}) => {
  axios
    .get(url, { params })
    .then((response) => {
      let flightData = [];
      const data = response.data;

      data.states.forEach((flight) => {
        let newFlightObject = {
          icao24: flight[0],
          callsign: flight[1],
          origin_country: flight[2],
          time_position: flight[3],
          last_contact: flight[4],
          longitude: flight[5],
          latitude: flight[6],
          baro_altitude: flight[7],
          on_ground: flight[8],
          velocity: flight[9],
          heading: flight[10],
          vertical_rate: flight[11],
          sensors: flight[12],
          geo_altitude: flight[13],
          sqawk: flight[14],
          spi: flight[15],
          position_source: flight[16],
          category: flight[17],
        };
        flightData.push(newFlightObject);
      });
      console.log(flightData);
      return flightData;
    })
    .catch((error) => {
      console.log(error);
    });
};

let url = "https://opensky-network.org/api/states/all";

const flightData = await getData(url).then((res) =>
  console.log("from promise")
);
