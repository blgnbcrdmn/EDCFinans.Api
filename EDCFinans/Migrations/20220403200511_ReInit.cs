using Microsoft.EntityFrameworkCore.Migrations;

namespace EDCFinans.Migrations
{
    public partial class ReInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depolar_Sehirler_SehirId",
                table: "Depolar");

            migrationBuilder.DropForeignKey(
                name: "FK_Depolar_Sirketler_SirketId",
                table: "Depolar");

            migrationBuilder.DropForeignKey(
                name: "FK_Faturalar_ParaBirimleri_ParaBirimiId",
                table: "Faturalar");

            migrationBuilder.DropForeignKey(
                name: "FK_Faturalar_Sirketler_SirketId",
                table: "Faturalar");

            migrationBuilder.DropForeignKey(
                name: "FK_GelirGiderler_Faturalar_FaturaId",
                table: "GelirGiderler");

            migrationBuilder.DropForeignKey(
                name: "FK_GelirGiderler_GelirGiderTurleri_GelirGiderTuruId",
                table: "GelirGiderler");

            migrationBuilder.DropForeignKey(
                name: "FK_Maaslar_Personeller_PersonelId",
                table: "Maaslar");

            migrationBuilder.DropForeignKey(
                name: "FK_Personeller_Meslekler_MeslekId",
                table: "Personeller");

            migrationBuilder.DropForeignKey(
                name: "FK_Sehirler_Ulkeler_UlkeId",
                table: "Sehirler");

            migrationBuilder.DropForeignKey(
                name: "FK_UrunDetaylar_Urunler_UrunId",
                table: "UrunDetaylar");

            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_UrunKategoriler_UrunKategoriId",
                table: "Urunler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Urunler",
                table: "Urunler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UrunKategoriler",
                table: "UrunKategoriler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UrunDetaylar",
                table: "UrunDetaylar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ulkeler",
                table: "Ulkeler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stoklar",
                table: "Stoklar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sirketler",
                table: "Sirketler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Siparisler",
                table: "Siparisler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SiparisDurumlar",
                table: "SiparisDurumlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SiparisDetaylar",
                table: "SiparisDetaylar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sehirler",
                table: "Sehirler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personeller",
                table: "Personeller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParaBirimleri",
                table: "ParaBirimleri");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meslekler",
                table: "Meslekler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Maaslar",
                table: "Maaslar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GelirGiderTurleri",
                table: "GelirGiderTurleri");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GelirGiderler",
                table: "GelirGiderler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Faturalar",
                table: "Faturalar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Depolar",
                table: "Depolar");

            migrationBuilder.RenameTable(
                name: "Urunler",
                newName: "Urun");

            migrationBuilder.RenameTable(
                name: "UrunKategoriler",
                newName: "UrunKategori");

            migrationBuilder.RenameTable(
                name: "UrunDetaylar",
                newName: "UrunDetay");

            migrationBuilder.RenameTable(
                name: "Ulkeler",
                newName: "Ulke");

            migrationBuilder.RenameTable(
                name: "Stoklar",
                newName: "Stok");

            migrationBuilder.RenameTable(
                name: "Sirketler",
                newName: "Sirket");

            migrationBuilder.RenameTable(
                name: "Siparisler",
                newName: "Siparis");

            migrationBuilder.RenameTable(
                name: "SiparisDurumlar",
                newName: "SiparisDurum");

            migrationBuilder.RenameTable(
                name: "SiparisDetaylar",
                newName: "SiparisDetay");

            migrationBuilder.RenameTable(
                name: "Sehirler",
                newName: "Sehir");

            migrationBuilder.RenameTable(
                name: "Personeller",
                newName: "Personel");

            migrationBuilder.RenameTable(
                name: "ParaBirimleri",
                newName: "ParaBirimi");

            migrationBuilder.RenameTable(
                name: "Meslekler",
                newName: "Meslek");

            migrationBuilder.RenameTable(
                name: "Maaslar",
                newName: "Maas");

            migrationBuilder.RenameTable(
                name: "GelirGiderTurleri",
                newName: "GelirGiderTuru");

            migrationBuilder.RenameTable(
                name: "GelirGiderler",
                newName: "GelirGider");

            migrationBuilder.RenameTable(
                name: "Faturalar",
                newName: "Fatura");

            migrationBuilder.RenameTable(
                name: "Depolar",
                newName: "Depo");

            migrationBuilder.RenameIndex(
                name: "IX_Urunler_UrunKategoriId",
                table: "Urun",
                newName: "IX_Urun_UrunKategoriId");

            migrationBuilder.RenameIndex(
                name: "IX_UrunDetaylar_UrunId",
                table: "UrunDetay",
                newName: "IX_UrunDetay_UrunId");

            migrationBuilder.RenameIndex(
                name: "IX_Sehirler_UlkeId",
                table: "Sehir",
                newName: "IX_Sehir_UlkeId");

            migrationBuilder.RenameIndex(
                name: "IX_Personeller_MeslekId",
                table: "Personel",
                newName: "IX_Personel_MeslekId");

            migrationBuilder.RenameIndex(
                name: "IX_Maaslar_PersonelId",
                table: "Maas",
                newName: "IX_Maas_PersonelId");

            migrationBuilder.RenameIndex(
                name: "IX_GelirGiderler_GelirGiderTuruId",
                table: "GelirGider",
                newName: "IX_GelirGider_GelirGiderTuruId");

            migrationBuilder.RenameIndex(
                name: "IX_GelirGiderler_FaturaId",
                table: "GelirGider",
                newName: "IX_GelirGider_FaturaId");

            migrationBuilder.RenameIndex(
                name: "IX_Faturalar_SirketId",
                table: "Fatura",
                newName: "IX_Fatura_SirketId");

            migrationBuilder.RenameIndex(
                name: "IX_Faturalar_ParaBirimiId",
                table: "Fatura",
                newName: "IX_Fatura_ParaBirimiId");

            migrationBuilder.RenameIndex(
                name: "IX_Depolar_SirketId",
                table: "Depo",
                newName: "IX_Depo_SirketId");

            migrationBuilder.RenameIndex(
                name: "IX_Depolar_SehirId",
                table: "Depo",
                newName: "IX_Depo_SehirId");

            migrationBuilder.AddColumn<int>(
                name: "DepoId",
                table: "Siparis",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SiparisId",
                table: "Siparis",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Urun",
                table: "Urun",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UrunKategori",
                table: "UrunKategori",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UrunDetay",
                table: "UrunDetay",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ulke",
                table: "Ulke",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stok",
                table: "Stok",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sirket",
                table: "Sirket",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Siparis",
                table: "Siparis",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SiparisDurum",
                table: "SiparisDurum",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SiparisDetay",
                table: "SiparisDetay",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sehir",
                table: "Sehir",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personel",
                table: "Personel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParaBirimi",
                table: "ParaBirimi",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meslek",
                table: "Meslek",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maas",
                table: "Maas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GelirGiderTuru",
                table: "GelirGiderTuru",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GelirGider",
                table: "GelirGider",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fatura",
                table: "Fatura",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Depo",
                table: "Depo",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stok_DepoId",
                table: "Stok",
                column: "DepoId");

            migrationBuilder.CreateIndex(
                name: "IX_Stok_UrunDetayId",
                table: "Stok",
                column: "UrunDetayId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_DepoId",
                table: "Siparis",
                column: "DepoId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_FaturaId",
                table: "Siparis",
                column: "FaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_SiparisDurumId",
                table: "Siparis",
                column: "SiparisDurumId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_SiparisId",
                table: "Siparis",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetay_SiparisId",
                table: "SiparisDetay",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetay_UrunDetayId",
                table: "SiparisDetay",
                column: "UrunDetayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Depo_Sehir_SehirId",
                table: "Depo",
                column: "SehirId",
                principalTable: "Sehir",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Depo_Sirket_SirketId",
                table: "Depo",
                column: "SirketId",
                principalTable: "Sirket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fatura_ParaBirimi_ParaBirimiId",
                table: "Fatura",
                column: "ParaBirimiId",
                principalTable: "ParaBirimi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fatura_Sirket_SirketId",
                table: "Fatura",
                column: "SirketId",
                principalTable: "Sirket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GelirGider_Fatura_FaturaId",
                table: "GelirGider",
                column: "FaturaId",
                principalTable: "Fatura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GelirGider_GelirGiderTuru_GelirGiderTuruId",
                table: "GelirGider",
                column: "GelirGiderTuruId",
                principalTable: "GelirGiderTuru",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Maas_Personel_PersonelId",
                table: "Maas",
                column: "PersonelId",
                principalTable: "Personel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personel_Meslek_MeslekId",
                table: "Personel",
                column: "MeslekId",
                principalTable: "Meslek",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sehir_Ulke_UlkeId",
                table: "Sehir",
                column: "UlkeId",
                principalTable: "Ulke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Siparis_Depo_DepoId",
                table: "Siparis",
                column: "DepoId",
                principalTable: "Depo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Siparis_Fatura_FaturaId",
                table: "Siparis",
                column: "FaturaId",
                principalTable: "Fatura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Siparis_Siparis_SiparisId",
                table: "Siparis",
                column: "SiparisId",
                principalTable: "Siparis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Siparis_SiparisDurum_SiparisDurumId",
                table: "Siparis",
                column: "SiparisDurumId",
                principalTable: "SiparisDurum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SiparisDetay_Siparis_SiparisId",
                table: "SiparisDetay",
                column: "SiparisId",
                principalTable: "Siparis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SiparisDetay_UrunDetay_UrunDetayId",
                table: "SiparisDetay",
                column: "UrunDetayId",
                principalTable: "UrunDetay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stok_Depo_DepoId",
                table: "Stok",
                column: "DepoId",
                principalTable: "Depo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stok_UrunDetay_UrunDetayId",
                table: "Stok",
                column: "UrunDetayId",
                principalTable: "UrunDetay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Urun_UrunKategori_UrunKategoriId",
                table: "Urun",
                column: "UrunKategoriId",
                principalTable: "UrunKategori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UrunDetay_Urun_UrunId",
                table: "UrunDetay",
                column: "UrunId",
                principalTable: "Urun",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depo_Sehir_SehirId",
                table: "Depo");

            migrationBuilder.DropForeignKey(
                name: "FK_Depo_Sirket_SirketId",
                table: "Depo");

            migrationBuilder.DropForeignKey(
                name: "FK_Fatura_ParaBirimi_ParaBirimiId",
                table: "Fatura");

            migrationBuilder.DropForeignKey(
                name: "FK_Fatura_Sirket_SirketId",
                table: "Fatura");

            migrationBuilder.DropForeignKey(
                name: "FK_GelirGider_Fatura_FaturaId",
                table: "GelirGider");

            migrationBuilder.DropForeignKey(
                name: "FK_GelirGider_GelirGiderTuru_GelirGiderTuruId",
                table: "GelirGider");

            migrationBuilder.DropForeignKey(
                name: "FK_Maas_Personel_PersonelId",
                table: "Maas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personel_Meslek_MeslekId",
                table: "Personel");

            migrationBuilder.DropForeignKey(
                name: "FK_Sehir_Ulke_UlkeId",
                table: "Sehir");

            migrationBuilder.DropForeignKey(
                name: "FK_Siparis_Depo_DepoId",
                table: "Siparis");

            migrationBuilder.DropForeignKey(
                name: "FK_Siparis_Fatura_FaturaId",
                table: "Siparis");

            migrationBuilder.DropForeignKey(
                name: "FK_Siparis_Siparis_SiparisId",
                table: "Siparis");

            migrationBuilder.DropForeignKey(
                name: "FK_Siparis_SiparisDurum_SiparisDurumId",
                table: "Siparis");

            migrationBuilder.DropForeignKey(
                name: "FK_SiparisDetay_Siparis_SiparisId",
                table: "SiparisDetay");

            migrationBuilder.DropForeignKey(
                name: "FK_SiparisDetay_UrunDetay_UrunDetayId",
                table: "SiparisDetay");

            migrationBuilder.DropForeignKey(
                name: "FK_Stok_Depo_DepoId",
                table: "Stok");

            migrationBuilder.DropForeignKey(
                name: "FK_Stok_UrunDetay_UrunDetayId",
                table: "Stok");

            migrationBuilder.DropForeignKey(
                name: "FK_Urun_UrunKategori_UrunKategoriId",
                table: "Urun");

            migrationBuilder.DropForeignKey(
                name: "FK_UrunDetay_Urun_UrunId",
                table: "UrunDetay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UrunKategori",
                table: "UrunKategori");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UrunDetay",
                table: "UrunDetay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Urun",
                table: "Urun");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ulke",
                table: "Ulke");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stok",
                table: "Stok");

            migrationBuilder.DropIndex(
                name: "IX_Stok_DepoId",
                table: "Stok");

            migrationBuilder.DropIndex(
                name: "IX_Stok_UrunDetayId",
                table: "Stok");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sirket",
                table: "Sirket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SiparisDurum",
                table: "SiparisDurum");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SiparisDetay",
                table: "SiparisDetay");

            migrationBuilder.DropIndex(
                name: "IX_SiparisDetay_SiparisId",
                table: "SiparisDetay");

            migrationBuilder.DropIndex(
                name: "IX_SiparisDetay_UrunDetayId",
                table: "SiparisDetay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Siparis",
                table: "Siparis");

            migrationBuilder.DropIndex(
                name: "IX_Siparis_DepoId",
                table: "Siparis");

            migrationBuilder.DropIndex(
                name: "IX_Siparis_FaturaId",
                table: "Siparis");

            migrationBuilder.DropIndex(
                name: "IX_Siparis_SiparisDurumId",
                table: "Siparis");

            migrationBuilder.DropIndex(
                name: "IX_Siparis_SiparisId",
                table: "Siparis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sehir",
                table: "Sehir");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personel",
                table: "Personel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParaBirimi",
                table: "ParaBirimi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meslek",
                table: "Meslek");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Maas",
                table: "Maas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GelirGiderTuru",
                table: "GelirGiderTuru");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GelirGider",
                table: "GelirGider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fatura",
                table: "Fatura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Depo",
                table: "Depo");

            migrationBuilder.DropColumn(
                name: "DepoId",
                table: "Siparis");

            migrationBuilder.DropColumn(
                name: "SiparisId",
                table: "Siparis");

            migrationBuilder.RenameTable(
                name: "UrunKategori",
                newName: "UrunKategoriler");

            migrationBuilder.RenameTable(
                name: "UrunDetay",
                newName: "UrunDetaylar");

            migrationBuilder.RenameTable(
                name: "Urun",
                newName: "Urunler");

            migrationBuilder.RenameTable(
                name: "Ulke",
                newName: "Ulkeler");

            migrationBuilder.RenameTable(
                name: "Stok",
                newName: "Stoklar");

            migrationBuilder.RenameTable(
                name: "Sirket",
                newName: "Sirketler");

            migrationBuilder.RenameTable(
                name: "SiparisDurum",
                newName: "SiparisDurumlar");

            migrationBuilder.RenameTable(
                name: "SiparisDetay",
                newName: "SiparisDetaylar");

            migrationBuilder.RenameTable(
                name: "Siparis",
                newName: "Siparisler");

            migrationBuilder.RenameTable(
                name: "Sehir",
                newName: "Sehirler");

            migrationBuilder.RenameTable(
                name: "Personel",
                newName: "Personeller");

            migrationBuilder.RenameTable(
                name: "ParaBirimi",
                newName: "ParaBirimleri");

            migrationBuilder.RenameTable(
                name: "Meslek",
                newName: "Meslekler");

            migrationBuilder.RenameTable(
                name: "Maas",
                newName: "Maaslar");

            migrationBuilder.RenameTable(
                name: "GelirGiderTuru",
                newName: "GelirGiderTurleri");

            migrationBuilder.RenameTable(
                name: "GelirGider",
                newName: "GelirGiderler");

            migrationBuilder.RenameTable(
                name: "Fatura",
                newName: "Faturalar");

            migrationBuilder.RenameTable(
                name: "Depo",
                newName: "Depolar");

            migrationBuilder.RenameIndex(
                name: "IX_UrunDetay_UrunId",
                table: "UrunDetaylar",
                newName: "IX_UrunDetaylar_UrunId");

            migrationBuilder.RenameIndex(
                name: "IX_Urun_UrunKategoriId",
                table: "Urunler",
                newName: "IX_Urunler_UrunKategoriId");

            migrationBuilder.RenameIndex(
                name: "IX_Sehir_UlkeId",
                table: "Sehirler",
                newName: "IX_Sehirler_UlkeId");

            migrationBuilder.RenameIndex(
                name: "IX_Personel_MeslekId",
                table: "Personeller",
                newName: "IX_Personeller_MeslekId");

            migrationBuilder.RenameIndex(
                name: "IX_Maas_PersonelId",
                table: "Maaslar",
                newName: "IX_Maaslar_PersonelId");

            migrationBuilder.RenameIndex(
                name: "IX_GelirGider_GelirGiderTuruId",
                table: "GelirGiderler",
                newName: "IX_GelirGiderler_GelirGiderTuruId");

            migrationBuilder.RenameIndex(
                name: "IX_GelirGider_FaturaId",
                table: "GelirGiderler",
                newName: "IX_GelirGiderler_FaturaId");

            migrationBuilder.RenameIndex(
                name: "IX_Fatura_SirketId",
                table: "Faturalar",
                newName: "IX_Faturalar_SirketId");

            migrationBuilder.RenameIndex(
                name: "IX_Fatura_ParaBirimiId",
                table: "Faturalar",
                newName: "IX_Faturalar_ParaBirimiId");

            migrationBuilder.RenameIndex(
                name: "IX_Depo_SirketId",
                table: "Depolar",
                newName: "IX_Depolar_SirketId");

            migrationBuilder.RenameIndex(
                name: "IX_Depo_SehirId",
                table: "Depolar",
                newName: "IX_Depolar_SehirId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UrunKategoriler",
                table: "UrunKategoriler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UrunDetaylar",
                table: "UrunDetaylar",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Urunler",
                table: "Urunler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ulkeler",
                table: "Ulkeler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stoklar",
                table: "Stoklar",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sirketler",
                table: "Sirketler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SiparisDurumlar",
                table: "SiparisDurumlar",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SiparisDetaylar",
                table: "SiparisDetaylar",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Siparisler",
                table: "Siparisler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sehirler",
                table: "Sehirler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personeller",
                table: "Personeller",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParaBirimleri",
                table: "ParaBirimleri",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meslekler",
                table: "Meslekler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maaslar",
                table: "Maaslar",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GelirGiderTurleri",
                table: "GelirGiderTurleri",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GelirGiderler",
                table: "GelirGiderler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Faturalar",
                table: "Faturalar",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Depolar",
                table: "Depolar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Depolar_Sehirler_SehirId",
                table: "Depolar",
                column: "SehirId",
                principalTable: "Sehirler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Depolar_Sirketler_SirketId",
                table: "Depolar",
                column: "SirketId",
                principalTable: "Sirketler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Faturalar_ParaBirimleri_ParaBirimiId",
                table: "Faturalar",
                column: "ParaBirimiId",
                principalTable: "ParaBirimleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Faturalar_Sirketler_SirketId",
                table: "Faturalar",
                column: "SirketId",
                principalTable: "Sirketler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GelirGiderler_Faturalar_FaturaId",
                table: "GelirGiderler",
                column: "FaturaId",
                principalTable: "Faturalar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GelirGiderler_GelirGiderTurleri_GelirGiderTuruId",
                table: "GelirGiderler",
                column: "GelirGiderTuruId",
                principalTable: "GelirGiderTurleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Maaslar_Personeller_PersonelId",
                table: "Maaslar",
                column: "PersonelId",
                principalTable: "Personeller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personeller_Meslekler_MeslekId",
                table: "Personeller",
                column: "MeslekId",
                principalTable: "Meslekler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sehirler_Ulkeler_UlkeId",
                table: "Sehirler",
                column: "UlkeId",
                principalTable: "Ulkeler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UrunDetaylar_Urunler_UrunId",
                table: "UrunDetaylar",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_UrunKategoriler_UrunKategoriId",
                table: "Urunler",
                column: "UrunKategoriId",
                principalTable: "UrunKategoriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
