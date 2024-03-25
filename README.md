C# DOT NET

The MOQ setup is under construction
<a href="https://patrick-gourdet.github.io/TaxDemo/" /><h1>GITHUB Pages for TAX API</h1> <<< Follow Link above >>></a>

<a width=150 href="https://hub.docker.com/r/pgourdet/auth"><<< click here for Docker >>>![DockerRepo](https://raisingcodeblog.com/wp-content/uploads/2019/03/whale-from-docker-logo-small-min.png)<h1>Tax Api Docker Container Repo</h1></a>


# The tax calculated may not be accurate as it uses the combined tax and does not have access to the nexus 
### Possibly could build a database with all the state to state regulations to create the Nexus lookup table.
### Documentation has indexed for lookup should a need arise...
# Auth
![Patricks GitHub stats](https://github-readme-stats.vercel.app/api?username=patrick-gourdet&count_private=true)
## This docker container has unit tests as well as API interaction using swagger, data storage is handled using Encrypted SQLite

# The Service contains user authentication authenticated API key, SQLite DB insert, and Calculation calls
# as well as other features

[![Build Status](https://img.shields.io/badge/Development-build-green)](https://fedigital.org)</br>

## To run project clone then open in Visual Studios 
## Download and install Docker-Desktop
## Execute in VisualStudios Using the docker file

## Troubleshoot: Delete Docker file and right-click project add Docker Support

# Test Calculation Method 
## Step 1: Register user using swagger
## Step 2: Save API Key using the credentials created in step 1
## Step 3: Make a call to API entering amount and ZIP code

## Test Tax rates endpoint will return the values for given zip code
## Enter password and the user 
## The Endpoint right above in swagger is geared towards more complicated queries, but the API key does not allow thus is not tested

# Using Unit tests, they are located together with the project on the test branch
## Run API Docker container 
## Must alter the user then run the test
## Then add a user to unit test 3
## all expected values should return 201 or 200

