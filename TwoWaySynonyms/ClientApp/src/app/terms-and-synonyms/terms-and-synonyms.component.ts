import { Component, OnInit, OnDestroy, ViewEncapsulation } from '@angular/core';
import { TermsAndSynonymsService } from '../services/terms-and-synonyms.service';
import { ITermAndSynonyms, ITermAndSynonymsInput } from '../models/terms-and-synonyms.models';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators'
import { FormGroup, FormControl, Validators } from '@angular/forms';
import * as config from '../app.configuration';

@Component({
  selector: 'terms-and-synonyms',
  templateUrl: './terms-and-synonyms.component.html',
  styleUrls: ['./terms-and-synonyms.component.css'],
})
export class TermsAndSynonymsComponent implements OnInit, OnDestroy {
  public termsAndSynonyms: ITermAndSynonyms[] = []
  private unsubscribe$ = new Subject();
  constructor(
    private termsAndSynonymsService: TermsAndSynonymsService
    ) { }

  public form: FormGroup 

  ngOnInit(): void {
    this.form = new FormGroup({
      term: new FormControl(''),
      synonyms: new FormControl('')
    })

    this.loadTermsAndSynonyms()
  }

  add(){
    const body = new ITermAndSynonymsInput(this.form.value.term, this.form.value.synonyms)
    this.termsAndSynonymsService.post(config.addNewTermWithSynonymsUrl, body)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(_ => {
        this.loadTermsAndSynonyms()
      },
      error => {
        console.log("Unable to add term and synonyms")
      })
  }

  private loadTermsAndSynonyms(){
    this.termsAndSynonymsService.get<ITermAndSynonyms[]>(config.getTermsWithSynonyms)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(termsAndSynonyms => {
        this.termsAndSynonyms = termsAndSynonyms
      },
      error => {
        console.log("Unable to load term and synonyms")
      })
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next()
    this.unsubscribe$.complete()
  }
}
