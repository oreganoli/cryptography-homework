import hashlib
import timeit
import plotly.express as px
import string
import random
ALGORITHM = "sha256"
strings_by_length = {}
time_by_length = {}
# Generate random strings of varying length:
for x in range(1024, 1024 * 4, 128):
    text = ""
    for n in range(0, x):
        text += random.choice(string.ascii_letters)
    strings_by_length[x] = text

# Measure the time it takes for our chosen algorithm to hash each message.
for length in strings_by_length:
    hasher = hashlib.new(ALGORITHM, strings_by_length[length].encode())
    time_by_length[length] = timeit.timeit(lambda: hasher.digest())

# Display a Plotly graph.

graph = px.line(None, x=time_by_length.keys(), y=time_by_length.values(
), title="SHA-256 hashing time depending on input length", labels={"x": "Input size [B]", "y": "Hashing time [s]"})
graph.show()
