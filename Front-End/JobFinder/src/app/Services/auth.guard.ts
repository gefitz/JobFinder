import { CanActivateFn } from '@angular/router';
import { ModalLoginService } from './modal-login.service';

export const authGuard: CanActivateFn = (route, state) => {
  return true;
};

