import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TermsAndSynonymsComponent } from './terms-and-synonyms.component';

describe('TermsAndSynonymsComponent', () => {
  let component: TermsAndSynonymsComponent;
  let fixture: ComponentFixture<TermsAndSynonymsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TermsAndSynonymsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TermsAndSynonymsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
