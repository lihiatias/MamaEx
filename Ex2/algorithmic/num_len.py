def num_len(num: int) -> int:
    return 1 + num_len(num // 10) if num >= 10 else 1
