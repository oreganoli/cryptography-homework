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