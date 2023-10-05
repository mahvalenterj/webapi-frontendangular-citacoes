import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { QuotesService } from '../_services/quotes-service';
import { QuoteRequest } from '../models/quote-request';
import { Quote } from '../models/quote';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'AngularProject';

  quotesForm: FormGroup;
  create: boolean = false;
  quotesList: Quote[] = [];
  edit: boolean = false;
  buttonCreate: boolean = false;
  quoteToEdit: Quote = new Quote(0, "", "");

  constructor(private formBuilder: FormBuilder, private quotesService: QuotesService) {
    this.quotesForm = this.formBuilder.group({
      author: ['', Validators.required],
      text: ['', Validators.required]
    });
  }
  ngOnInit(): void {
    this.updateQuotes();
    }

  showCreate() {
    this.create = !this.create;
  }

  updateQuotes() {
    this.quotesService.getAll().subscribe({
      next: (response) => {
        this.quotesList = response;
      },
      error: (error) => {
        console.error('Error getting quotes', error);
      }
    });
  }

  onSubmit() {
    if (this.edit === true) {
      let quoteToUpdate = new Quote(this.quoteToEdit.id, this.quotesForm.controls['author'].value, this.quotesForm.controls['text'].value)

      this.quotesService.update(quoteToUpdate).subscribe({
        next: (response) => {
          this.edit = false;
          this.create = false;
          this.buttonCreate = false;
          this.updateQuotes();
        },
        error: (error) => {
          console.log(error);
        }
      });
    }
    else {
      let quote = new QuoteRequest(this.quotesForm.controls['author'].value, this.quotesForm.controls['text'].value)

      this.quotesService.create(quote).subscribe({
        next: (response) => {
          console.log(response);
          this.create = false;
          this.updateQuotes();
        },
        error: (error) => {
          console.log(error);
        }
      })
    }
    
  }

  delete(id: number) {
    this.quotesService.delete(id).subscribe({
      next: (response) => {
        this.updateQuotes();
      },
      error: (error) => {
        console.log(error);
      }
    })
  }

  editQuote(id: number) {
    this.quotesService.getById(id).subscribe({
      next: (response) => {
        if (response) {
          this.buttonCreate = true;
          this.edit = true;
          this.quoteToEdit = response;
          this.create = true;
          this.quotesForm.controls['author'].setValue(this.quoteToEdit.author);
          this.quotesForm.controls['text'].setValue(this.quoteToEdit.text);
        }
        else {
          console.log("Não foi possível encontrar a cotação");
        }
      },
      error: (error) => {
        console.log(error);
      }
    })
  }

}
