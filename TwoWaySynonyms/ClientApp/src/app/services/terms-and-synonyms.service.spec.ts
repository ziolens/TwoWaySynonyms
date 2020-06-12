import { TestBed } from '@angular/core/testing';

import { TermsAndSynonymsService } from './terms-and-synonyms.service';

describe('TermsAndSynonymsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TermsAndSynonymsService = TestBed.get(TermsAndSynonymsService);
    expect(service).toBeTruthy();
  });
});
