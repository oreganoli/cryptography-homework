import hashlib as hl
import timeit as ti


def hash_string(algo_name: str, text: str):
    hasher = hl.new(algo_name)
    hasher.update(text.encode())
    # The shake_128 and shake_256 algorithms return outputs of dynamic length.
    if algo_name.startswith("shake_"):
        return hasher.digest(64)
    else:
        return hasher.digest()


hash_input = input("Enter the input string to be hashed:\n>")
algorithm_times = {}
for algorithm in hl.algorithms_available:
    algorithm_times[algorithm] = ti.timeit(
        lambda: hash_string(algorithm, hash_input)
    )
for algorithm in algorithm_times:
    print(f"{algorithm}: {algorithm_times[algorithm]}")
