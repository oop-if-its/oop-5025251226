// File ini berisi TODO -- lihat SOAL.md untuk kontrak lengkap tiap level.
// Bagian bertanda TODO(Level N) adalah tugas kalian; kode lain sudah
// disediakan. Jangan mengubah nama/tipe yang sudah ada kecuali TODO
// memintanya secara eksplisit.

namespace Pertemuan08;

// Bonus (Level 10): mengumpulkan SEMUA kesalahan sebelum melapor, alih-alih
// berhenti di kesalahan pertama.
public static class ValidatorAnggota
{
    private static List<string> Periksa(string nama, string nrp, int usia)
    {
        var galat = new List<string>();
        // TODO(Level 10): kumpulkan pesan ke daftar `galat`, TANPA berhenti di
        //   kesalahan pertama: nama null/kosong/spasi -> "Nama wajib diisi"; nrp
        //   bukan tepat 10 digit angka (null juga tidak valid) -> "NRP harus 10
        //   digit"; usia di luar 17..80 -> "Usia harus 17-80". Urutannya harus
        //   begitu (nama, nrp, usia).

        // 1. Periksa nama (null, kosong, atau hanya terdiri dari spasi)
        if (string.IsNullOrWhiteSpace(nama))
        {
            galat.Add("Nama wajib diisi");
        }

        // 2. Periksa NRP (harus tepat 10 digit angka; null tidak valid)
        if (string.IsNullOrEmpty(nrp) || nrp.Length != 10 || !long.TryParse(nrp, out _))
        {
            galat.Add("NRP harus 10 digit");
        }

        // 3. Periksa usia (di luar rentang 17 sampai 80)
        if (usia < 17 || usia > 80)
        {
            galat.Add("Usia harus 17-80");
        }

        return galat;
    }

    public static void Validasi(string nama, string nrp, int usia)
    {
        // TODO(Level 10): bila ada kesalahan (dari Periksa), lempar
        //   ValidasiException dengan SELURUH daftarnya; kalau tidak ada, tidak
        //   terjadi apa-apa.
        var galat = Periksa(nama, nrp, usia);
        if (galat.Count > 0)
        {
            throw new ValidasiException(galat);
        }
    }

    public static bool TryValidasi(string nama, string nrp, int usia, out IReadOnlyList<string> daftarError)
    {
        // TODO(Level 10): versi TANPA exception (pola TryXxx): isi daftarError
        //   dengan hasil Periksa dan kembalikan true kalau daftarnya kosong.
        //   TIDAK boleh melempar exception.
        var galat = Periksa(nama, nrp, usia);
        daftarError = galat.AsReadOnly();
        return galat.Count == 0;
    }
}
