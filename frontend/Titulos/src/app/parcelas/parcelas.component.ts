import { formatDate, DatePipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Parcela } from '../models/Parcela';
import { ParcelasService } from './parcelas.service';

@Component({
  selector: 'app-parcelas',
  templateUrl: './parcelas.component.html',
  styleUrls: ['./parcelas.component.css']
})
export class ParcelasComponent implements OnInit {

  title = "Parcelas";
  criandoNovaParcela = false;
  @Input() dividaId: number = 0;

  public parcelaForm: FormGroup;

  // public parcelas = [
  //   { id: 1, numero: 1010, valor: 100.0 },
  //   { id: 2, numero: 1011, valor: 110.0 },
  //   { id: 3, numero: 1012, valor: 120.0 },
  //   { id: 4, numero: 1013, valor: 130.0 },
  //   { id: 5, numero: 1014, valor: 140.0 }
  // ];
  public parcelas: Parcela[] = [];

  public parcelaSelecionada: Parcela = new Parcela();

  constructor(private fb: FormBuilder,
    private parcelasService: ParcelasService) {
    this.criarForm();
  }

  ngOnInit(): void {
    this.carregarParcelas(this.dividaId);
  }

  SelectParcela(parcela: Parcela) {
    this.parcelaSelecionada = parcela;
    this.parcelaSelecionada.dividaId = this.dividaId;
    this.parcelaForm.patchValue(parcela);
    this.parcelaForm.get('dataVencimento')?.patchValue(this.formatDate(this.parcelaSelecionada.dataVencimento));
  }

  private formatDate(date: Date) {
    const d = new Date(date);
    let month = '' + (d.getMonth() + 1);
    console.log(d.getMonth());
    let day = '' + d.getDate();
    const year = d.getFullYear();
    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;
    return [year, month, day].join('-');
  }

  DiselectParcela() {
    this.parcelaSelecionada = new Parcela();
    this.criandoNovaParcela = false;
  }

  criarForm() {
    this.parcelaForm = this.fb.group({
      id: [''],
      numero: ['', Validators.required],
      valor: ['', Validators.required],
      dataVencimento: ['', Validators.required],
      dividaId: [''],
    });
  }

  parcelaSubmit() {
    this.salvarParcela(this.parcelaForm.value);
  }

  carregarParcelas(id: number) {
    this.parcelasService.getByDividaId(id).subscribe(
      (parcelas: Parcela[]) => {
        this.parcelas = parcelas;
      },
      (erro: any) => {
        console.error(erro);
      }
    )
  }

  salvarParcela(parcela: Parcela) {

    if (parcela.id == 0) {
      this.parcelasService.post(parcela).subscribe(
        (parcela: Parcela) => {
          console.log(parcela);
          this.carregarParcelas(this.dividaId)
        },
        (erro: any) => {
          console.error(erro)
        })
    }
    else {
      this.parcelasService.put(parcela).subscribe(
        (parcela: Parcela) => {
          console.log(parcela);
          this.carregarParcelas(this.dividaId)
        },
        (erro: any) => {
          console.error(erro)
        }
      )
    }

    this.DiselectParcela();

  }

  removerParcela(id: number) {
    this.parcelasService.delete(id).subscribe(
      (result) => {
        console.log(result);
        this.carregarParcelas(this.dividaId);
      },
      (erro: any) => {
        console.error(erro);
      }
    )
  }

  cadastrarParcela() {
    this.parcelaSelecionada = new Parcela();
    this.parcelaSelecionada.dividaId = this.dividaId;
    this.parcelaForm.patchValue(this.parcelaSelecionada)
    this.criandoNovaParcela = true;
  }

}
