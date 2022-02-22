import hashlib
import os
import urllib.request as req
ALPINE_SHA256 = "9050b323c5ad35efd21e157c9d700fb2e096d8bfa05c458e81914e82a9312695"
ALPINE_DL_URL = "https://dl-cdn.alpinelinux.org/alpine/v3.15/releases/x86/alpine-standard-3.15.0-x86.iso"

# Reads a file over HTTP and dumps it as in-memory bytes.


def download_file(url):
    return req.urlopen(url).read()

# (Exercise 3) Returns the SHA-256 hash of a file on disk in hexadecimal.


def hash_file(path):
    file = open(path, "rb")
    return hashlib.sha256(file.read()).hexdigest()


# Download the Alpine Linux installation ISO.
iso = download_file(ALPINE_DL_URL)
iso_hash = hashlib.sha256(iso).hexdigest()
assert(iso_hash == ALPINE_SHA256)
# Save to disk and use the function from exercise 3.
temp_file = open("temp.iso", "wb")
temp_file.write(iso)
temp_file.close()
temp_hash = hash_file("temp.iso")
assert(temp_hash == ALPINE_SHA256)
os.remove("temp.iso")
