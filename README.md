# MaterialsCalculator
A simple API project to calculate the area of a room, volume of a room and number of tins required to paint the walls when give the dimensions of the room and paint information.

## Setup
Clone or download the project and open the MaterialsCalculator.sln file in Visual Studio 2017 (may work in earlier versions but this has not been tested!).

Build the solution.


## Features
The API exposes two API endpoints:

GET http://localhost:52068/api/Materials/Paint
This endpoint responds to a simple GET request with a 200 response that has a JSON message in its body.  The JSON message contains an array of JSON elements, each representing a paint that is in stock, e.g.

  `[
      {
          "PaintId": 1,
          "PaintName": "Magnolia",
          "CoverageM2PerTin": 10
      },
      {
          "PaintId": 2,
          "PaintName": "White",
          "CoverageM2PerTin": 12
      },
      {
          "PaintId": 3,
          "PaintName": "Green",
          "CoverageM2PerTin": 9.5
      }
  ]`

POST http://localhost:52068/api/Materials/Paint/CalculateQuantity/SquareRoom
This endpoint responds to a POST request that has a JSON message in its body. The JSON message must provide the dimensions of the room and the desired paintId (obtained from previous call) for which to perform the coverage calculation. It MUST be in the following format:

  `{
      "PaintId": 1,
      "Height": 2.0,
      "Width": 4.0,
      "Length": 5.0
  }`

The endpoint will return a 200 response that has a JSON message in its body which contains the following information, for example:

  `{ 
      "PaintInfo": { 
          "PaintId": 1, 
          "Height": 2, 
          "Width": 4, 
          "Length": 5 
      }, 
      "Area": 36, 
      "Volume": 40, 
      "CoverageM2PerTin": 10, 
      "TinsRequired": 3.6 
  }` 

The area is that of the walls only.  If an invalid PaintId is sent then a 404 response is returned.


## Unit Tests
Unit test projects are located in the solution-level folder named Tests.  Use the unit tests to see behaviour of individual components.


## Run the Api
From visual studio, hit F5 to run the project.

A browser window will open and try to navigate to a home page which is not available but the application will be running listening to http port 52068.

Open a tool such as PostMan and make a GET request to http://localhost:52068/api/Materials/Paint.

The response will contain a JSON that indicates the available paints and their IDs.  Select a valid PaintId and use it for the following step.

Send a POST request to http://localhost:52068/api/Materials/Paint/CalculateQuantity/SquareRoom making sure to include a JSON object in the body of the request that describes the area of the room to be painted and an valid PaintId from the previous request.  For example:

  `{
      "PaintId": 1,
      "Height": 2.0,
      "Width": 4.0,
      "Length": 5.0
  }`

A 200 response will be received which contains a JSON message that gives the original JSON message provided in the request, plus the Area and Volume of the room and the number of tins of the selected paint required to paint the walls.


## Future of the API
While over-engineered for the current features, the idea for the API is that it could be extended at one end to provide end points for different shaped rooms and materials such as wall paper or plaster.  At the other end it could be extended to be provided with material information from different data sources such as databases or material vendor APIs.
