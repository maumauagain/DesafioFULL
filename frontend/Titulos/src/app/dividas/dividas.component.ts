import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Divida } from '../models/Divida';
import { DividasService } from './dividas.service';

@Component({
  selector: 'app-dividas',
  templateUrl: './dividas.component.html',
  styleUrls: ['./dividas.component.css']
})
export class DividasComponent implements OnInit {

  public dividaForm: FormGroup;
  public modalRef: BsModalRef;
  public modalDialogRef: BsModalRef;
  public selectedDivida: Divida = new Divida();
  public criandoNovaDivida = false;
  @Input() dividaId: number = 0;


  // public dividas: any = [
  //   { id: 1, numero: 1010, nomeDevedor: "Miguel", numParcelas: 1, valorOriginal: 200.0, diasEmAtraso: 10, valorAtualizado: 205.0 },
  //   { id: 2, numero: 1012, nomeDevedor: "Vanessa", numParcelas: 2, valorOriginal: 210.0, diasEmAtraso: 11, valorAtualizado: 215.0 },
  //   { id: 3, numero: 1013, nomeDevedor: "Alessandro", numParcelas: 3, valorOriginal: 220.59, diasEmAtraso: 12, valorAtualizado: 225.0 },
  //   { id: 4, numero: 1014, nomeDevedor: "Henrique", numParcelas: 4, valorOriginal: 230.0, diasEmAtraso: 13, valorAtualizado: 235.0 },
  //   { id: 5, numero: 1015, nomeDevedor: "Carlao", numParcelas: 5, valorOriginal: 240.0, diasEmAtraso: 14, valorAtualizado: 245.0 }
  // ];
  public dividas: Divida[] = [];
  public message: string = "";

  constructor(private fb: FormBuilder,
    private modalService: BsModalService,
    private dividasService: DividasService) {
    this.criarForm();
  }

  openModal(template: TemplateRef<any>, id: number) {
    this.modalRef = this.modalService.show(template);
    this.dividaId = id;
  }

  openDialogModal(template: TemplateRef<any>, id: number) {
    this.modalDialogRef = this.modalService.show(template, { class: 'modal-sm' });
    this.dividaId = id;
  }

  confirm(): void {
    this.excluirDivida(this.dividaId);
    this.modalDialogRef.hide();
  }

  decline(): void {
    this.modalDialogRef.hide();
  }

  SelectDivida(divida: Divida) {
    this.criandoNovaDivida = false;
    this.selectedDivida = divida;
    this.carregarDividaPorId(divida.id);
  }
  DiselectDivida() {
    this.selectedDivida = new Divida();
    this.criandoNovaDivida = false;
  }

  ngOnInit(): void {
    this.carregarDividas();
  }

  carregarDividas() {
    this.dividasService.getAll().subscribe(
      (dividas: Divida[]) => {
        this.dividas = dividas
      },
      (erro: any) => {
        console.error(erro);
      }
    );
  }

  carregarDividaPorId(id: number) {
    this.dividasService.getById(id).subscribe(
      (divida: Divida) => {
        this.selectedDivida = divida
        this.dividaForm.patchValue(this.selectedDivida);
      },
      (erro: any) => {
        console.error(erro)
      }
    )
  }

  criarForm() {
    this.dividaForm = this.fb.group({
      id: [''],
      numero: ['', Validators.required],
      nomeDevedor: ['', Validators.required],
      cpfDevedor: ['', Validators.required],
      juros: ['', Validators.required],
      multa: ['', Validators.required]
    });
  }

  dividaSubmit() {
    this.salvarDivida(this.dividaForm.value);
    console.log(this.dividaForm.value);
    this.DiselectDivida();
  }

  salvarDivida(divida: Divida) {

    if (this.selectedDivida.id == 0) {
      this.dividasService.post(divida).subscribe(
        (result) => {
          console.log(result)
          this.carregarDividas()
        },
        (erro: any) => {
          console.error(erro);
        }
      );
    }
    else {
      this.dividasService.put(divida).subscribe(
        (result) => {
          console.log(result)
          this.carregarDividas()
        },
        (erro: any) => {
          console.error(erro);
        }
      );
    }

  }

  excluirDivida(id: number) {
    this.dividasService.delete(id).subscribe(
      (result) => {
        console.log(result);
        this.carregarDividas();
      },
      (erro: any) => {
        console.log(erro);
      }
    )
  }

  cadastrarDivida() {
    this.selectedDivida = new Divida();
    this.dividaForm.patchValue(this.selectedDivida)
    this.criandoNovaDivida = true;
  }

  fecharModal() {
    this.carregarDividas();
    this.modalRef.hide();
  }
}
