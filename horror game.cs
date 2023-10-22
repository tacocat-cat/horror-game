Python
import random
import pygame

# Define some constants.
SCREEN_WIDTH = 800
SCREEN_HEIGHT = 600
PLAYER_SPEED = 5
ENEMY_SPEED = 3

# Create a Pygame window.
screen = pygame.display.set_mode((SCREEN_WIDTH, SCREEN_HEIGHT))

# Create the player sprite.
player = pygame.sprite.Sprite()
player.image = pygame.Surface((32, 32))
player.image.fill((255, 0, 0))
player.rect = player.image.get_rect()
player.rect.center = (SCREEN_WIDTH / 2, SCREEN_HEIGHT / 2)

# Create a list to store the enemies.
enemies = []

# Start the game loop.
while True:

  # Handle events.
  for event in pygame.event.get():
    if event.type == pygame.QUIT:
      pygame.quit()
      sys.exit()

    # Handle keyboard input.
    if event.type == pygame.KEYDOWN:
      if event.key == pygame.K_UP:
        player.rect.y -= PLAYER_SPEED
      elif event.key == pygame.K_DOWN:
        player.rect.y += PLAYER_SPEED
      elif event.key == pygame.K_LEFT:
        player.rect.x -= PLAYER_SPEED
      elif event.key == pygame.K_RIGHT:
        player.rect.x += PLAYER_SPEED

  # Update the player's position.
  player.rect.clamp_ip(screen.get_rect())

  # Update the enemies' positions.
  for enemy in enemies:
    enemy.rect.x -= ENEMY_SPEED

    # If the enemy goes off the screen, remove it from the list.
    if enemy.rect.x < 0:
      enemies.remove(enemy)

    # If the enemy collides with the player, the player loses.
    if enemy.rect.colliderect(player.rect):
      print("You lose!")
      pygame.quit()
      sys.exit()

  # Spawn a new enemy every second.
  if random.random() < 0.01:
    enemy = pygame.sprite.Sprite()
    enemy.image = pygame.Surface((32, 32))
    enemy.image.fill((255, 255, 255))
    enemy.rect = enemy.image.get_rect()
    enemy.rect.x = SCREEN_WIDTH
    enemy.rect.y = random.randint(0, SCREEN_HEIGHT - enemy.rect.height)
    enemies.append(enemy)

  # Draw the screen.
  screen.fill((0, 0, 0))
  screen.blit(player.image, player.rect)
  for enemy in enemies:
    screen.blit(enemy.image, enemy.rect)

  # Update the display.
  pygame.display.flip()




