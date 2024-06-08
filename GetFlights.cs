using UnityEngine;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

public class FlightData
{
    public string icao24;
    public string callsign;
    public string origin_country;
    public double time_position;
    public double last_contact;
    public double longitude;
    public double latitude;
    public double baro_altitude;
    public bool on_ground;
    public double velocity;
    public double heading;
    public double vertical_rate;
    public int sensors;
    public double geo_altitude;
    public string sqawk;
    public bool spi;
    public int position_source;
    public string category;
}

public class FlightDataManager : MonoBehaviour
{
    private async void Start()
    {
        string url = "https://opensky-network.org/api/states/all";
        List<FlightData> flightData = await GetData(url);
        Debug.Log("Data received: " + flightData.Count + " flights");
    }

    private async Task<List<FlightData>> GetData(string url)
    {
        List<FlightData> flightData = new List<FlightData>();

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                dynamic jsonData = JsonUtility.FromJson<dynamic>(jsonString);

                foreach (var flight in jsonData.states)
                {
                    FlightData newFlightObject = new FlightData
                    {
                        icao24 = flight[0],
                        callsign = flight[1],
                        origin_country = flight[2],
                        time_position = flight[3],
                        last_contact = flight[4],
                        longitude = flight[5],
                        latitude = flight[6],
                        baro_altitude = flight[7],
                        on_ground = flight[8],
                        velocity = flight[9],
                        heading = flight[10],
                        vertical_rate = flight[11],
                        sensors = flight[12],
                        geo_altitude = flight[13],
                        sqawk = flight[14],
                        spi = flight[15],
                        position_source = flight[16],
                        category = flight[17]
                    };
                    flightData.Add(newFlightObject);
                }
            }
            else
            {
                Debug.LogError("Failed to fetch data: " + response.StatusCode);
            }
        }

        return flightData;
    }
}
