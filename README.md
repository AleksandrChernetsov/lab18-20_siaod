# Priority Queue (Max-Heap) – Windows Forms App

This Windows Forms application demonstrates a **priority queue** implemented as a **max‑heap** (pyramidal tree).  
It supports the core operations:

- Building a heap from random values
- Inserting a new element
- Extracting the maximum element (with automatic heap restoration)
- Changing the priority of an existing element
- Clearing the queue

The heap is visualised both as a **flat array** and as a **tree structure**.  
Extracted elements are stored in a separate “Results” array.

<img width="713" height="408" alt="image" src="https://github.com/user-attachments/assets/b7340241-b21f-4af0-be0d-be17dab1c2da" />

## ✨ Features

- **Create queue** – fills the heap with 15 random numbers (10–99) using successive `Up` (sift‑up) operations.
- **Clear queue** – resets the heap and clears all visualisations.
- **Insert new element** – adds a user‑specified value (10–99) and restores the heap property.
- **Extract max** – removes the root (largest element), stores it in the “Results” array, and restores the heap with `Down` (sift‑down).
- **Change priority** – finds an element by its old value and replaces it with a new value; automatically calls `Up` or `Down` depending on whether the priority increased or decreased.
- **Visualisations**:
  - Top table: heap as a linear array (15 cells).
  - Middle table: heap as a binary tree (4 rows, root at row 0, column 7).
  - Bottom table: extracted elements in order of removal.
- **Error handling** – message boxes for empty queue, full queue (max 15 elements), element not found, or result array overflow (max 15 extracted values).

## 🧮 Operations & Algorithms

| Operation | Algorithm / Method | Notes |
|-----------|--------------------|-------|
| Insert    | `Up(int[] A, int k)` | Sift‑up from the new leaf to restore max‑heap order. |
| Extract max | `Down(int[] A, int k, int n)` | Replace root with last element, then sift‑down from root. |
| Change priority | Find index, then `Up` or `Down` | If new value > old → sift‑up; if new value < old → sift‑down. |
| Display (array) | `Print(int[] A)` | Fills `dataGridView1` (1 row, 15 columns). |
| Display (tree) | `Print(int[] A)` | Fills `dataGridView2` (4 rows, 15 columns) with positions fixed for a complete binary tree of height 3. |
| Clear | `Clear_Tab()` | Clears all three tables (empty strings). |

## 🚀 How to Use

1. **Run the application** – open the solution in Visual Studio (2022 or later) and press `F5`.
2. **Create queue** – click **“Создать очередь”** to generate 15 random numbers and build the heap.
3. **View the heap** – the top table shows the array representation; the middle table shows the tree.
4. **Insert a new element** – set the value in the first `NumericUpDown` (10–99) and click **“Вставить новый”**.
5. **Extract maximum** – click **“Извлечь наибольший”**. The extracted value appears in the bottom “Results” table. You can extract up to 15 elements.
6. **Change priority** – enter the old value in the second `NumericUpDown`, the new value in the third, then click **“Изменить приоритет”**. The heap is updated accordingly.
7. **Clear queue** – click **“Очистить очередь”** to reset everything.
8. **Exit** – click **“Выход”** to close the application.

> **Note:** The heap size is limited to **15 elements**. Attempts to insert beyond this limit show an error message.  
> The results array also holds at most 15 extracted values.

## 🛠️ Requirements

- **.NET** 6.0 or higher (Windows Forms)
- **Visual Studio** 2022 (or any C# IDE with Windows Forms designer)
- **Operating System**: Windows (Windows Forms dependency)

## 📦 Build & Run

1. Clone the repository or copy the source files into a new Windows Forms project.
2. Ensure the project targets `.NET 6.0` (or later).
3. Build the solution (`Ctrl+Shift+B`).
4. Run the application (`F5`).

## 📊 Example Workflow

| Step | Action | Heap (array) | Heap (tree) | Results |
|------|--------|--------------|--------------|---------|
| 1 | Create queue | `[85, 72, 63, 54, 48, 42, 33, 27, 19, 15, 12, 10, 9, 7, 5]` | Root = 85, children = 72, 63 … | empty |
| 2 | Extract max | `[72, 54, 63, 27, 48, 42, 33, 5, 19, 15, 12, 10, 9, 7, 0]` | New root = 72 | `[85]` |
| 3 | Insert 90 | `[90, 72, 63, 54, 48, 42, 33, 27, 19, 15, 12, 10, 9, 7, 5]` | Root = 90 | `[85]` |
| 4 | Change priority: 33 → 80 | `[90, 80, 63, 54, 72, 42, 33, 27, 19, 15, 12, 10, 9, 7, 5]` | Node 80 moves up | `[85]` |

## 📝 Notes

- The tree visualisation uses fixed column positions (e.g., root at column 7, level 1 at columns 3 and 11, etc.) for a complete binary tree with up to 15 nodes.
- Empty cells are shown as blank (empty string) – the code treats `0` as “no element”, but note that valid priorities are between 10 and 99, so `0` is safe as a sentinel.
- The “Change priority” operation searches for the **first occurrence** of the old value. If duplicates exist, only the first is modified.

## 📄 License

Project created for educational purposes. Free use and modification are permitted with attribution.

---

**Author:** Aleksandr Chernetsov  
**Group:** 24VP1
