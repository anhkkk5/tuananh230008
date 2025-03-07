const apiUrl = "https://localhost:7236/api/hanghoa/"; // Đổi theo API của bạn

// ✅ Lấy danh sách hàng hóa từ API
async function fetchGoods() {
  try {
    const response = await fetch(apiUrl);
    if (!response.ok) throw new Error(`Lỗi API: ${response.status}`);
    const goods = await response.json();

    const tableBody = document.getElementById("goodsTableBody");
    tableBody.innerHTML = "";

    goods.forEach((hangHoa) => {
      const row = `
                <tr>
                    <td>${hangHoa.maHangHoa}</td>
                    <td>${hangHoa.tenHangHoa}</td>
                    <td>${hangHoa.soLuong}</td>
                    <td>${hangHoa.ghiChu || "Không có ghi chú"}</td>
                    <td>
                        <button onclick="updateGhiChu('${
                          hangHoa.id
                        }')">📝 Sửa</button>
                        <button onclick="deleteGoods('${
                          hangHoa.id
                        }')">❌ Xóa</button>
                    </td>
                </tr>
            `;
      tableBody.innerHTML += row;
    });
  } catch (error) {
    console.error("Lỗi khi tải danh sách hàng hóa:", error);
  }
}

// ✅ Thêm hàng hóa mới
async function createGoods() {
  const maHangHoa = document.getElementById("maHangHoa").value.trim();
  const tenHangHoa = document.getElementById("tenHangHoa").value.trim();
  const soLuong = document.getElementById("soLuong").value.trim();
  const ghiChu = document.getElementById("ghiChu").value.trim();

  if (maHangHoa.length !== 9) {
    alert("Mã hàng hóa phải có đúng 9 ký tự!");
    return;
  }

  const newGoods = {
    maHangHoa,
    tenHangHoa,
    soLuong: parseInt(soLuong) || 0,
    ghiChu,
  };

  try {
    const response = await fetch(apiUrl, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(newGoods),
    });

    if (!response.ok) {
      const errorText = await response.text();
      throw new Error(`Lỗi API: ${response.status} - ${errorText}`);
    }

    alert("Thêm hàng hóa thành công!");
    fetchGoods();
  } catch (error) {
    console.error("Lỗi khi thêm hàng hóa:", error);
    alert("Lỗi khi thêm hàng hóa: " + error.message);
  }
}

// ✅ Xóa hàng hóa
async function deleteGoods(id) {
  if (!confirm("Bạn có chắc muốn xóa hàng hóa này?")) return;

  try {
    const response = await fetch(`${apiUrl}${id}`, {
      method: "DELETE",
      headers: { "Content-Type": "application/json" },
    });

    if (!response.ok) {
      const errorText = await response.text();
      throw new Error(`Lỗi API: ${response.status} - ${errorText}`);
    }

    alert("Xóa hàng hóa thành công!");
    fetchGoods();
  } catch (error) {
    console.error("Lỗi khi xóa hàng hóa:", error);
    alert("Lỗi khi xóa hàng hóa: " + error.message);
  }
}

// ✅ Cập nhật ghi chú
async function updateGhiChu(id) {
  const newNote = prompt("Nhập ghi chú mới:");
  if (newNote !== null) {
    try {
      const response = await fetch(`${apiUrl}${id}/ghi-chu`, {
        method: "PATCH",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ ghiChu: newNote }), // Dữ liệu đúng định dạng API yêu cầu
      });

      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Lỗi API: ${response.status} - ${errorText}`);
      }

      alert("Cập nhật ghi chú thành công!");
      fetchGoods();
    } catch (error) {
      console.error("Lỗi khi cập nhật ghi chú:", error);
      alert("Lỗi khi cập nhật ghi chú: " + error.message);
    }
  }
}

// ✅ Gọi API khi trang tải xong
window.onload = fetchGoods;
