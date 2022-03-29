from fastapi import FastAPI

app = FastAPI()

# Symmetric API stubs

@app.get("/symmetric/key")
async def sym_get_key():
    return {"message": "This is a stub."}
@app.post("/symmetric/key")
async def sym_set_key():
    return {"message": "This is a stub."}
@app.post("/symmetric/encrypt")
async def sym_encrypt():
    return {"message": "This is a stub."}
@app.post("/symmetric/decrypt")
async def sym_decrypt():
    return {"message": "This is a stub."}

# Asymmetric API stubs

@app.get("/asymmetric/key")
async def asym_get_key():
    return {"message": "This is a stub."}
@app.post("/asymmetric/key")
async def asym_set_key():
    return {"message": "This is a stub."}
@app.post("/asymmetric/verify")
async def asym_verify():
    return {"message": "This is a stub."}
@app.post("/asymmetric/sign")
async def asym_sign():
    return {"message": "This is a stub."}
@app.post("/asymmetric/encrypt")
async def asym_decrypt():
    return {"message": "This is a stub."}
@app.post("/asymmetric/decrypt")
async def asym_encrypt():
    return {"message": "This is a stub."}
