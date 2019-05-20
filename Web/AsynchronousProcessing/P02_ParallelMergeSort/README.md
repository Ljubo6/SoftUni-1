**Parallel Merge Sort** (_Implemented by async methods_)

Time Comparisons Table: sync vs async sorting

| Number of elements | Time\* (in ms) | |
| --- | --- | --- |
|  | Sync MergeSort | Parallel MergeSort |
| 100,000 | 6,339 | 1,960 |
| 200,000 | 20,338 | 4,075 |
| 300,000 | 69,600 | 5,935 |
| 1,000,000  | exceeds 100,000 | 20,082 |

*average time of five tests ran on the same set of elements
