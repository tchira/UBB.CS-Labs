(defun vale (l)
"Sa se scrie o functie care sa testeze daca o lista liniara formata din
numere
intregi are aspect de vale(o multime se spune ca are aspect de vale
daca elementele descresc pana la un moment dat, apoi cresc. De ex.
10 8 6 17 19 20)."
(cond ((null l) nil)
(t (vale_aux 0 l))
)
)

(defun vale_aux (n l)
(cond ((and (= n 1) (null (cdr l))) t)
((and (= n 0) (> (car l) (car (cdr l)))) (vale_aux 0 (cdr l)))
((and (= n 0) (< (car l) (car (cdr l)))) (vale_aux 1 (cdr l)))
((and (= n 1) (< (car l) (car (cdr l)))) (vale_aux 1 (cdr l)))
)
)

