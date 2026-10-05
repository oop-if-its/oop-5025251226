# Diagram Hierarki Kelas (UML) — Perpustakaan

Gambarkan diagram UML yang menunjukkan **hubungan antar kelas** di pertemuan ini, di bagian **bawah** penanda di akhir berkas ini. Format bebas — boleh kotak ASCII/Mermaid (`classDiagram`) atau daftar bertingkat. Yang wajib ada:

- Kelas `Anggota`, `Mahasiswa`, `Dosen`, `Asisten`, `Alamat`, dan `LogAktivitas`.
- Hubungan **pewarisan** (*is-a*): panah segitiga kosong dari kelas turunan ke kelas induk (`<|--` di Mermaid, atau `▲`, atau tulis "extends"/"turunan dari").
- Hubungan **komposisi** (*has-a*): berlian terisi dekat pihak pemilik (`*--` di Mermaid, atau `◆`, atau tulis "komposisi"/"memiliki") — siapa memiliki siapa?
- Anggota `protected` ditandai dengan simbol `#` (mis. `# BatasPinjam`), `public` dengan `+`, `private` dengan `-`.

Contoh format Mermaid (untuk kelas lain, bukan jawaban):

```mermaid
classDiagram
    Kendaraan <|-- Mobil
    Mobil *-- Mesin
    class Kendaraan {
        + Merek : string
        # kecepatan : int
    }
```

Jangan hapus baris penanda di bawah ini — jawaban kalian harus ditulis **setelah** baris itu, bukan sebelumnya.

<!-- TULIS JAWABAN KALIAN DI BAWAH BARIS INI -->

classDiagram
    Anggota <|-- Mahasiswa
    Anggota <|-- Dosen
    Mahasiswa <|-- Asisten
    Anggota *-- Alamat
    Anggota *-- LogAktivitas

    class Alamat {
        +string Jalan
        +string Kota
        +ToString() string
    }

    class LogAktivitas {
        +IReadOnlyList~string~ Semua
        +Catat(string aktivitas) void
    }

    class Anggota {
        +string Id
        +string Nama
        +Alamat Alamat
        #int BatasPinjam
        +int JumlahPinjam
        -LogAktivitas _log
        +IReadOnlyList~string~ Riwayat
        +Info() string
        +Pinjam(string judul) void
    }

    class Mahasiswa {
        +string Nrp
        +string Prodi
        +InfoLengkap() string
    }

    class Dosen {
        +string Nip
        +InfoLengkap() string
    }

    class Asisten {
        +string MataKuliah
        +InfoAsisten() string
    }