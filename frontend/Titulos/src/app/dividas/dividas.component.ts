import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Divida } from '../models/Divida';

@Component({
  selector: 'app-dividas',
  templateUrl: './dividas.component.html',
  styleUrls: ['./dividas.component.css']
})
export class DividasComponent implements OnInit {

  public dividaForm: FormGroup;
  public modalRef: BsModalRef;
  public selectedDivida: Divida = new Divida();

  public dividas: any = [
    { id: 1, numero: 1010, nomeDevedor: "Miguel", numParcelas: 1, valorOriginal: 200.0, diasEmAtraso: 10, valorAtualizado: 205.0 },
    { id: 2, numero: 1012, nomeDevedor: "Vanessa", numParcelas: 2, valorOriginal: 210.0, diasEmAtraso: 11, valorAtualizado: 215.0 },
    { id: 3, numero: 1013, nomeDevedor: "Alessandro", numParcelas: 3, valorOriginal: 220.59, diasEmAtraso: 12, valorAtualizado: 225.0 },
    { id: 4, numero: 1014, nomeDevedor: "Henrique", numParcelas: 4, valorOriginal: 230.0, diasEmAtraso: 13, valorAtualizado: 235.0 },
    { id: 5, numero: 1015, nomeDevedor: "Carlao", numParcelas: 5, valorOriginal: 240.0, diasEmAtraso: 14, valorAtualizado: 245.0 }
  ];



  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }


  SelectDivida(divida: Divida) {
    this.selectedDivida = divida;
    this.dividaForm.patchValue(divida);
  }
  DiselectDivida() {
    this.selectedDivida = new Divida();
  }

  constructor(private fb: FormBuilder,
    private modalService: BsModalService) {
    this.criarForm();
  }

  ngOnInit(): void {
  }

  criarForm() {
    this.dividaForm = this.fb.group({
      numero: ['', Validators.required],
      nomeDevedor: ['', Validators.required],
      cpfDevedor: ['', Validators.required],
      juros: ['', Validators.required],
      multa: ['', Validators.required]
    });
  }

  dividaSubmit() {
    console.log(this.dividaForm.value);
  }

}
