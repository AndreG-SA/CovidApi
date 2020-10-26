# CovidApi

Unfortunately I cannot run something on port 5000 on my machine, this is a company laptop and there is already some service running on port 5000.
I tried really hard, but could not get rid of it.


It looks like the way to get the most accurate details is to first make a call to get a list of countries.
Then iterate through the list of countries to download its history for the day.
We can use the first record for the day which probably produces the most accurate data.

I created an async foreach loop to try and make the numerous calls to the server a bit faster
