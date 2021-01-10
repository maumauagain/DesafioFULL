import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Parcela } from '../models/Parcela';

@Component({
  selector: 'app-parcelas',
  templateUrl: './parcelas.component.html',
  styleUrls: ['./parcelas.component.css']
})
export class ParcelasComponent implements OnInit {

  title = "Parcelas";

  public parcelaForm: FormGroup;

  public parcelas = [
    { id: 1, numero: 1010, valor: 100.0 },
    { id: 2, numero: 1011, valor: 110.0 },
    { id: 3, numero: 1012, valor: 120.0 },
    { id: 4, numero: 1013, valor: 130.0 },
    { id: 5, numero: 1014, valor: 140.0 }
  ];

  public parcelaSelecionada: Parcela = new Parcela();

  SelectParcela(parcela: Parcela) {
    this.parcelaSelecionada = parcela;
    this.parcelaForm.patchValue(parcela);
  }

  DiselectParcela() {
    this.parcelaSelecionada = new Parcela();
  }

  constructor(private fb: FormBuilder) {
    this.criarForm();
  }

  ngOnInit(): void {
  }

  criarForm() {
    this.parcelaForm = this.fb.group({
      numero: ['', Validators.required],
      valor: ['', Validators.required]
    });
  }

  parcelaSubmit() {
    console.log(this.parcelaForm.value);
  }

}
