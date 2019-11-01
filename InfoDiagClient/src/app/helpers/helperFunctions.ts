import { ToastrService } from 'ngx-toastr';

export function handleError(errorMessage: string, toastrService: ToastrService) {
    toastrService.error(errorMessage, 'Erreur');
}